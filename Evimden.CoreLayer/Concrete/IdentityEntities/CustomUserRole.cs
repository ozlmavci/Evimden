using Evimden.CoreLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Evimden.CoreLayer.Concrete.IdentityEntities
{
    public class CustomUserRole : IdentityUserRole<Guid>, IEntity
    {
        public virtual CustomUser User { get; set; }
        public virtual CustomRole Role { get; set; }
    }
}
