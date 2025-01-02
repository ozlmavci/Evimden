using Evimden.CoreLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Evimden.CoreLayer.Concrete.IdentityEntities
{
    public class CustomUserLogin : IdentityUserLogin<Guid>, IEntity
    {
        public virtual CustomUser User { get; set; }
    }
}
