using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EI.Portal.Addresses.Dto
{
    [AutoMapFrom(typeof(Address))]
    public class AddressDto : AuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(Address.MaxStreetLength)]
        public string Street { get; set; }
        [Required]
        [StringLength(Address.MaxNumberLength)]
        public string Number { get; set; }
        public string Complement { get; set; }
        [Required]
        [StringLength(Address.MaxDistrictLength)]
        public string District { get; set; }
        [Required]
        [StringLength(Address.MaxCepLength)]
        public string Cep { get; set; }
        [Required]
        public string City { get; set; }
        public string Uf { get; set; }
        public string Country { get; set; }
    }
}
