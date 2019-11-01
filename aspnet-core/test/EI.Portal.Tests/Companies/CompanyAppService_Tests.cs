using Abp.UI;
using EI.Portal.Companies;
using EI.Portal.Companies.Dto;
using EI.Portal.Companies.Exceptions;
using EI.Portal.Companies.Interfaces;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EI.Portal.Tests.Companies
{
    public class CompanyAppService_Tests : PortalTestBase
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyAppService_Tests()
        {
            _companyAppService = Resolve<ICompanyAppService>();
            UsingDbContext(context => new TestCompanyBuilder(context).Build());
        }

        [Fact]
        public async Task Should_Get_All_Companies()
        {
            var result = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany());

            result.Items.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Should_Get_Account_Companies()
        {
            var result = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany() { Types = Portal.Companies.Type.Accounting });

            result.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_FInal_Companies()
        {
            var result = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany() { Types = Portal.Companies.Type.Final });

            result.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_By_Id()
        {
            var company = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany() { Types = Portal.Companies.Type.Final });
            var id = company.Items.FirstOrDefault().Id;

            var result = await _companyAppService.GetById(id);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Should_Get_By_Parent()
        {
            var company = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany() { Types = Portal.Companies.Type.Accounting });
            var id = company.Items.FirstOrDefault().Id;

            var result = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany() { ParentId = id });

            result.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Create_Company_Without_Cnpj()
        {
            await Assert.ThrowsAsync<Abp.Runtime.Validation.AbpValidationException>(async () => await _companyAppService.CreateUpdateAsync(new CreateUpdateCompanyDto(null, null, Portal.Companies.Type.Accounting)));
        }

        [Fact]
        public async Task Create_Company_Cnpj_Major_18_Lengthj()
        {
            await Assert.ThrowsAsync<Abp.Runtime.Validation.AbpValidationException>(async () => await _companyAppService.CreateUpdateAsync(new CreateUpdateCompanyDto("00.000.000/0001-001", "Company Test", Portal.Companies.Type.EI)));
        }

        [Fact]
        public async Task Create_Company_Cnpj_Minor_14_Lengthj()
        {
            await Assert.ThrowsAsync<CnpjException>(async () => await _companyAppService.CreateUpdateAsync(new CreateUpdateCompanyDto("00.000.000/00", "Company Test", Portal.Companies.Type.EI)));
        }

        [Fact]
        public async Task Create_Company_Without_Name()
        {
            await Assert.ThrowsAsync<Abp.Runtime.Validation.AbpValidationException>(async () => await _companyAppService.CreateUpdateAsync(new CreateUpdateCompanyDto("00.000.000/0001-00", null, Portal.Companies.Type.Accounting)));
        }

        [Fact]
        public async Task Create_Company_Name_Empty()
        {
            await Assert.ThrowsAsync<Abp.Runtime.Validation.AbpValidationException>(async () => await _companyAppService.CreateUpdateAsync(new CreateUpdateCompanyDto("00.000.000/0001-00", "", Portal.Companies.Type.Accounting)));
        }

        [Fact]
        public async Task Create_Company_Accounting_Without_Parent()
        {
            await Assert.ThrowsAsync<UserFriendlyException>(async () => await _companyAppService.CreateUpdateAsync(new CreateUpdateCompanyDto("00.000.000/0001-00", "COMPANY TEST", Portal.Companies.Type.Accounting)));
        }

        [Fact]
        public async Task Create_Company_Final_Without_Parent()
        {
            await Assert.ThrowsAsync<UserFriendlyException>(async () => await _companyAppService.CreateUpdateAsync(new CreateUpdateCompanyDto("00.000.000/0001-00", "COMPANY TEST", Portal.Companies.Type.Final)));
        }

        [Fact]
        public async Task Create_Company_Accounting_Success()
        {
            var companiesResult = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany() { Types = Portal.Companies.Type.EI });
            var ei = companiesResult.Items.FirstOrDefault();

            var accounting = new CreateUpdateCompanyDto("00.000.000/0001-00", "COMPANY TEST", Portal.Companies.Type.Accounting, null, ei.Id);

            var guid = await _companyAppService.CreateUpdateAsync(accounting);

            guid.ShouldNotBe(Guid.Empty);
        }

        [Fact]
        public async Task Create_Company_Final_Success()
        {
            var companiesResult = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany() { Types = Portal.Companies.Type.Accounting });
            var accounting = companiesResult.Items.FirstOrDefault();

            var final = new CreateUpdateCompanyDto("00.000.000/0001-00", "COMPANY TEST", Portal.Companies.Type.Final, null, accounting.Id);

            var guid = await _companyAppService.CreateUpdateAsync(final);

            guid.ShouldNotBe(Guid.Empty);
        }

        [Fact]
        public async Task Udapte_Company_Success()
        {
            var companiesResult = await _companyAppService.GetAll(new Portal.Companies.Dto.GetAllFilterCompany() { Types = Portal.Companies.Type.Accounting });
            var accounting = companiesResult.Items.FirstOrDefault();

            var final = new CreateUpdateCompanyDto("00.000.000/0001-00", "COMPANY TEST", Portal.Companies.Type.Final, null, accounting.Id);

            var guid = await _companyAppService.CreateUpdateAsync(final);
           
            final.Id = guid;
            final.Name = "KRATOS COMPANY TEST";

            var updatedGuid = await _companyAppService.CreateUpdateAsync(final);
            var updatedEntity = await _companyAppService.GetById(updatedGuid);

            updatedEntity.Name.ShouldBe(final.Name);
            updatedGuid.ShouldBe(guid);

        }
    }
}
