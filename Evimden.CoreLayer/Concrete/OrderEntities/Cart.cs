using Evimden.CoreLayer.Concrete.IdentityEntities;

namespace Evimden.CoreLayer.Concrete.OrderEntities
{
    public class Cart: BaseEntity
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public decimal SubTotal { get; set; }

        public CustomUser User { get; set; }

        public List<ProductCart> ProductCarts { get; set; }
    }
}
