using System.Threading.Tasks;
using Abp.Application.Services;
using EI.Portal.Authorization.Accounts.Dto;

namespace EI.Portal.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
