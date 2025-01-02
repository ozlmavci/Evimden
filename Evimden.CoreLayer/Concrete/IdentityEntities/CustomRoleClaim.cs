using Evimden.CoreLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Evimden.CoreLayer.Concrete.IdentityEntities
{
    public class CustomRoleClaim : IdentityRoleClaim<Guid>, IEntity
    {
        public virtual CustomRole Role { get; set; }
    }
}
