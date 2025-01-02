using Evimden.CoreLayer.Abstract;

namespace Evimden.CoreLayer.DTOs.IdentityDTOs
{
    public class CustomUserRoleDto : IDtoModel
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
