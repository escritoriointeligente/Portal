using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using EI.Portal.Authorization.Roles;
using EI.Portal.Authorization.Users;
using EI.Portal.MultiTenancy;
using EI.Portal.Companies;
using EI.Portal.Addresses;
using EI.Portal.Departments;

namespace EI.Portal.EntityFrameworkCore
{
    public class PortalDbContext : AbpZeroDbContext<Tenant, Role, User, PortalDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Department> Department { get; set; }

        public PortalDbContext(DbContextOptions<PortalDbContext> options)
            : base(options)
        {
        }
    }
}
