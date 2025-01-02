using Evimden.CoreLayer.Concrete.IdentityEntities;

namespace Evimden.CoreLayer.Concrete.ProfileEntities
{
    public class Phone : BaseEntity
    {
        public Guid PhoneId { get; set; }
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }

        public CustomUser User { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
