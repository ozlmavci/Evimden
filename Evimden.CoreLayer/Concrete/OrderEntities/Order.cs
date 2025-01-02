using Evimden.CoreLayer.Common.Enums;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.Concrete.ProfileEntities;

namespace Evimden.CoreLayer.Concrete.OrderEntities
{
    public class Order : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid SellerId { get; set; }
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public Guid PaymentId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusEnum OrderStatus { get; set; } = OrderStatusEnum.Bekliyor;
        public int Quantity { get; set; }
        public string? CargoTrackingCode { get; set; } = string.Empty;

        public Seller Seller { get; set; }
        public CustomUser User { get; set; }
        public Address Address { get; set; }
        public Payment Payment { get; set; }
        public Product Product { get; set; }

    }
}
