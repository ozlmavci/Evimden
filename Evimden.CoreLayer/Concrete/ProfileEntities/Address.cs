using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.Concrete.OrderEntities;

namespace Evimden.CoreLayer.Concrete.ProfileEntities
{
    public class Address : BaseEntity
    {
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public Guid PhoneId { get; set; }
        public int CountryId { get; set; } = 90;
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string? AddressText { get; set; }
        public  bool IsFavorite { get; set; }

        public CustomUser User { get; set; }
        public Phone Phone { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }

        public List<Order> Orders { get; set; }
    }
}
