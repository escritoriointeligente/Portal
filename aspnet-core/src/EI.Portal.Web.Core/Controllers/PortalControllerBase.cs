using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EI.Portal.Controllers
{
    public abstract class PortalControllerBase: AbpController
    {
        protected PortalControllerBase()
        {
            LocalizationSourceName = PortalConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
