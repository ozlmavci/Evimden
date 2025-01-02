using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;

namespace Evimden.BusinessLayer.Interfaces.IdentityInterfaces
{
    public interface IUserService : IService<CustomUser, CustomUserDto>
    {
        public Task<CustomUserDto> UserRegisterAsync(CustomUserDto customUserDto);
        public Task<CustomUserDto> UserLoginAsync(CustomUserDto customUserDto);
        public Task<CustomUserDto> UserUpdateAsync(CustomUserDto customUserDto);
        public Task<CustomUserDto> PasswordChangeAsync(CustomUserDto customUserDto);
        public Task<List<string>> GetUserRolesAsync(Guid userId);
    }
}
