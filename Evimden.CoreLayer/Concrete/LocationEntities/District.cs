using Evimden.CoreLayer.Abstract;
using Evimden.CoreLayer.Concrete.ProfileEntities;

namespace Evimden.CoreLayer.Concrete.LocationEntities
{
    public class District : IEntity
    {
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; } = 90;
        public string DistrictName { get; set; }

        public City City { get; set; }

        public List<Address> Addresses { get; set; }
        public List<Seller> Sellers { get; set; }
    }
}
