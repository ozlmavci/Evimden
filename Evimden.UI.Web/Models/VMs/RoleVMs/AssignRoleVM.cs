using Evimden.CoreLayer.DTOs.IdentityDTOs;
using Evimden.UI.Web.Models.VMs.IdentityVMs;

namespace Evimden.UI.Web.Models.VMs.RoleVMs
{
    public class AssignRoleVM
    {
        public List<UserMiniVM> Users { get; set; } 
        public List<CustomRoleDto> Roles { get; set; }
        public string RoleName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
