using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EI.Portal.Companies.Dto
{
    [AutoMapTo(typeof(Company))]
    public class CreateUpdateCompanyDto : AuditedEntityDto<Guid>, IShouldNormalize
    {
        public CreateUpdateCompanyDto()
        {

        }

        public CreateUpdateCompanyDto(string cnpj, string name, Type type, Guid? addressId = null, Guid? parentId = null) : this()
        {
            Cnpj = cnpj;
            Name = name;
            Type = type;
            AddressId = addressId;
            ParentId = parentId;
        }

        [Required]
        [StringLength(Company.MaxCnpjLength)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(Company.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(Company.MaxNameLength)]
        public string FantasyName { get; set; }
        public string Img { get; set; }
        public Type Type { get; set; }
        public bool Active { get; set; } = true;
        public Guid? AddressId { get; set; }
        public Guid? ParentId { get; set; }

        public void Normalize()
        {
            if(!String.IsNullOrEmpty(Cnpj))
                Cnpj = new String(Cnpj.Where(Char.IsDigit).ToArray());

            if (!String.IsNullOrEmpty(Name))
                Name = Name.ToUpper();

            if (!String.IsNullOrEmpty(FantasyName))
                Name = FantasyName.ToUpper();

            if (String.IsNullOrEmpty(FantasyName))
                FantasyName = Name;
        }
    }
}
