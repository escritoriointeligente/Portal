using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using EI.Portal.Companies.Dto;
using EI.Portal.Companies.Exceptions;
using EI.Portal.Companies.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EI.Portal.Companies
{
    public class CompanyAppService : PortalAppServiceBase, ICompanyAppService
    {
        private readonly IRepository<Company, Guid> _companyRepository;

        public CompanyAppService(IRepository<Company, Guid> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Guid> CreateUpdateAsync(CreateUpdateCompanyDto company)
        {
            if (company.Cnpj.Length < 14)
                throw new CnpjException("Cnpj deve ser informado no formato 00.000.000/0001-00 ou 00.000000000100.");

            if (company.Type == Type.Accounting || company.Type == Type.Final)
                if (company.ParentId == Guid.Empty || company.ParentId == null)
                    throw new UserFriendlyException("É necessario selecionar uma CONTABILIDADE para cadastrar a empresa atual.");

            var entity = ObjectMapper.Map<Company>(company);

            await _companyRepository.InsertOrUpdateAndGetIdAsync(entity);

            return entity.Id;
        }

        public async Task<ListResultDto<CompanyListDto>> GetAll(GetAllFilterCompany filter)
        {
            var query = _companyRepository
                .GetAll()
                .Include(a => a.Parent)
                .Include(a => a.Address)
                .WhereIf(filter.ParentId.HasValue, c => c.ParentId == filter.ParentId)
                .WhereIf(filter.Types.HasValue, t => t.Type == filter.Types.Value)
                .OrderByDescending(c => c.CreationTime);

            var result = await query.ToListAsync();

            return new ListResultDto<CompanyListDto>(
                    ObjectMapper.Map<List<CompanyListDto>>(result)
                );
        }

        public async Task<CompanyDto> GetById(Guid id)
        {
            var query = _companyRepository
               .GetAll()
               .Include(a => a.Parent)
               .WhereIf(id != Guid.Empty, c => c.Id == id)
               .OrderByDescending(c => c.CreationTime);

            var result = await query.FirstOrDefaultAsync();

            return ObjectMapper.Map<CompanyDto>(result);
        }
    }
}
