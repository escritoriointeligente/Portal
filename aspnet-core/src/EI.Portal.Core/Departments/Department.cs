﻿using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EI.Portal.Departments
{
    [Table("Department")]
    public class Department : AuditedEntity<Guid>
    {
        public const int MaxNameLength = 25;

        public Department()
        {

        }

        public Department(string name) : this()
        {
            Name = name;                
        }

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }
    }
}
