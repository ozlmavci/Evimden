using Evimden.CoreLayer.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Evimden.CoreLayer.Concrete.IdentityEntities
{
    public class CustomUserToken : IdentityUserToken<Guid> , IEntity
    {
        public virtual CustomUser User { get; set; }    
    }
}
