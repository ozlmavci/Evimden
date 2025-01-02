using Evimden.CoreLayer.Abstract;
using Evimden.CoreLayer.Concrete.CargoEntities;
using Evimden.CoreLayer.Concrete.ProfileEntities;

namespace Evimden.CoreLayer.Concrete.LocationEntities
{
    public class Country : IEntity
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public List<City> Cities { get; set; }
        public List<Seller> Sellers { get; set; }
        public List<Shipper> Shippers { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
