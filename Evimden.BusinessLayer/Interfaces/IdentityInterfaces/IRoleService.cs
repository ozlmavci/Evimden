using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.DTOs.IdentityDTOs;

namespace Evimden.BusinessLayer.Interfaces.IdentityInterfaces
{
    public interface IRoleService : IService<CustomRole, CustomRoleDto>
    {
        Task<CustomRoleDto> AddRoleAsync(CustomRoleDto customRoleDto);
        public Task<bool> AssignRoleAsync(string UserName, string roleName);
    }
}