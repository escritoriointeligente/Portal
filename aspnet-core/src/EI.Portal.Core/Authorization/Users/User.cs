using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Authorization.Users;
using Abp.Extensions;
using EI.Portal.Departments;

namespace EI.Portal.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }
        public Guid? DepartmentId { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
