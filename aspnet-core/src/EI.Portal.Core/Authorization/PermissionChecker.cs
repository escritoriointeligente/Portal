using Abp.Authorization;
using EI.Portal.Authorization.Roles;
using EI.Portal.Authorization.Users;

namespace EI.Portal.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
