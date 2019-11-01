using Abp.Authorization.Users;
using Abp.Domain.Entities.Auditing;
using EI.Portal.Addresses;
using EI.Portal.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EI.Portal.Companies
{
    [Table("Company")]
    public class Company : AuditedEntity<Guid>
    {
        public Company()
        {

        }

        public Company(string cnpj, string name, Type type, Guid? addressId = null, Guid? parentId = null) : this()
        {
            Cnpj = cnpj;
            Name = name;
            Type = type;
            AddressId = addressId;
            ParentId = parentId;
        }

        public const int MaxNameLength = 256;
        public const int MaxCnpjLength = 18;

        [Required]
        [StringLength(MaxCnpjLength)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        [StringLength(MaxNameLength)]
        public string FantasyName { get; set; }
        public string Img { get; set; }
        public Type Type { get; set; }
        public bool Active { get; set; } = true;

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }
        public Guid? AddressId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Company Parent { get; set; }
        public Guid? ParentId { get; set; }
    }

    public enum Type : byte
    {
        EI = 0,
        Accounting = 1,
        Final = 2
    }

}
