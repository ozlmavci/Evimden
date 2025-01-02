using Evimden.CoreLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Evimden.CoreLayer.Concrete.IdentityEntities
{
    public class CustomRole : IdentityRole<Guid>, IEntity
    {
        public virtual ICollection<CustomRoleClaim> RoleClaims { get; set; }
        public virtual ICollection<CustomUserRole> UserRoles { get; set; }
    }
}
