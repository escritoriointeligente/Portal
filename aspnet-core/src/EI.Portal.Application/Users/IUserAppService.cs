using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EI.Portal.Roles.Dto;
using EI.Portal.Users.Dto;

namespace EI.Portal.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
