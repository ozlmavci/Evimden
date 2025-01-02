using Evimden.CoreLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Evimden.CoreLayer.Concrete.IdentityEntities
{
    public class CustomUserClaim : IdentityUserClaim<Guid>, IEntity
    {
        public virtual CustomUser User { get; set; }
    }
}
