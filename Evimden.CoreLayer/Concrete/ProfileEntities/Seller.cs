using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.Concrete.LocationEntities;
using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.Concrete.ProductEntities;

namespace Evimden.CoreLayer.Concrete.ProfileEntities
{
    public class Seller : BaseEntity
    {
        public Guid SellerId { get; set; }
        public Guid UserId { get; set; }
        public int CountryId { get; set; } = 90;
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string ShopName { get; set; }
        public string Tckn { get; set; }
        public string Vkn { get; set; }
        public string ShopImagePath { get; set; }
        public string About { get; set; }
        public bool IsApproved { get; set; } = false;
        public bool IsBanned { get; set; } = false;

        public CustomUser User { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }

        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<SellerApproval> SellerApprovals { get; set; }
    }
}
