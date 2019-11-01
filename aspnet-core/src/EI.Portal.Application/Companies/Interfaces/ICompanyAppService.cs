using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EI.Portal.Companies.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EI.Portal.Companies.Interfaces
{
    public interface ICompanyAppService : IApplicationService
    {
        Task<ListResultDto<CompanyListDto>> GetAll(GetAllFilterCompany type);
        Task<CompanyDto> GetById(Guid id);
        Task<Guid> CreateUpdateAsync(CreateUpdateCompanyDto company);
    }
}
