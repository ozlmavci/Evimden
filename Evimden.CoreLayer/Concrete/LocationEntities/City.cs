using Evimden.CoreLayer.Abstract;
using Evimden.CoreLayer.Concrete.ProfileEntities;

namespace Evimden.CoreLayer.Concrete.LocationEntities
{
    public class City : IEntity
    {
        public int CityId { get; set; }
        public int CountryId { get; set; } = 90;
        public string CityName { get; set; }

        public Country Country { get; set; }

        public List<District> Districts { get; set; }

        public List<Address> Addresses { get; set; }
        public List<Seller> Sellers { get; set; }
    }
}
