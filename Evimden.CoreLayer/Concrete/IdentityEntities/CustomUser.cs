using Evimden.CoreLayer.Abstract;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Microsoft.AspNetCore.Identity;

namespace Evimden.CoreLayer.Concrete.IdentityEntities
{
    public class CustomUser : IdentityUser<Guid>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<CustomUserClaim> UserClaims { get; set; }
        public virtual ICollection<CustomUserLogin> UserLogins { get; set; }
        public virtual ICollection<CustomUserRole> UserRoles { get; set; }
        public virtual ICollection<CustomUserToken> UserTokens { get; set; }

        public List<Order> Orders { get; set; }

    }
}
