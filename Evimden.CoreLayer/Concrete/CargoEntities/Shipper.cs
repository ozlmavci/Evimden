using Evimden.CoreLayer.Concrete.LocationEntities;

namespace Evimden.CoreLayer.Concrete.CargoEntities
{
    public class Shipper : BaseEntity
    {
        public Guid ShipperId { get; set; }
        public int CountryId { get; set; } = 90;
        public string ShipperName { get; set; }
        public string? ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? ApiUrl { get; set; }
        public string? ApiKey { get; set; }
        public Country Country { get; set; }
    }
}
