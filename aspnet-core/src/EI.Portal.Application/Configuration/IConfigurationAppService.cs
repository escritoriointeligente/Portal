using System.Threading.Tasks;
using EI.Portal.Configuration.Dto;

namespace EI.Portal.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
