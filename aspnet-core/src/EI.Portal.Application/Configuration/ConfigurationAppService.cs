using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EI.Portal.Configuration.Dto;

namespace EI.Portal.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PortalAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
