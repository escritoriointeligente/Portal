using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EI.Portal.MultiTenancy.Dto;

namespace EI.Portal.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

