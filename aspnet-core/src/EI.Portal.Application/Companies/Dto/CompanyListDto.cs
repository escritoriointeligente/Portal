using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace EI.Portal.Companies.Dto
{
    [AutoMapFrom(typeof(Company))]
    public class CompanyListDto : AuditedEntityDto<Guid>
    {
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string FantasyName { get; set; }
        public string Img { get; set; }
        public Type Type { get; set; }
        public bool Active { get; set; } = true;
        public Guid? AddressId { get; set; }
        public string AddressStreet { get; set; }
        public string AddressNumber { get; set; }
        public string AddressCep { get; set; }
        public string AddressCity { get; set; }
        public string AddressDistrict { get; set; }
        public string AddressUf { get; set; }
        public string AddressCountry { get; set; }
        public Guid? ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
