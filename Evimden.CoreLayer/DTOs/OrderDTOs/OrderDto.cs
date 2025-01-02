using Evimden.CoreLayer.Common.Enums;

namespace Evimden.CoreLayer.DTOs.OrderDTOs
{
    public class OrderDto : BaseDto
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
        public string CargoTrackingCode { get; set; } = string.Empty;
    }
}
