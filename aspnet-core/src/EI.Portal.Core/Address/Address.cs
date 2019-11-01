using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EI.Portal.Addresses
{
    [Table("Address")]
    public class Address : AuditedEntity<Guid>
    {

        public const int MaxStreetLength = 256;
        public const int MaxNumberLength = 20;
        public const int MaxComplementLength = 256;
        public const int MaxDistrictLength = 256;
        public const int MaxCepLength = 9;

        public Address()
        {

        }

        public Address(string street, string number, string cep, string city, string district) : this()
        {
            Street = street;
            Number = number;
            Cep = cep;
            City = city;
            District = district;
        }

        [Required]
        [StringLength(MaxStreetLength)]
        public string Street { get; set; }

        [Required]
        [StringLength(MaxNumberLength)]
        public string Number { get; set; }
        public string Complement { get; set; }
        [Required]
        [StringLength(MaxDistrictLength)]
        public string District { get; set; }
        [Required]
        [StringLength(MaxCepLength)]
        public string Cep { get; set; }
        [Required]
        public string City { get; set; }
        public string Uf { get; set; }
        public string Country { get; set; } = "Brasil";
       
    }
}
