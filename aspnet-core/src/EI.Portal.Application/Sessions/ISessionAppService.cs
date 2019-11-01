using System.Threading.Tasks;
using Abp.Application.Services;
using EI.Portal.Sessions.Dto;

namespace EI.Portal.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
