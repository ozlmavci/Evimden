using Evimden.CoreLayer.Common.Enums;

namespace Evimden.CoreLayer.DTOs.OrderDTOs
{
    public class PaymentDto : BaseDto
    {
        public Guid PaymentId { get; set; }
        public int PaymentType { get; set; } 
        public Guid PaymentInformationId { get; set; }
        public Guid? CouponId { get; set; }
        public DateTime PaymentDate { get; set; }
        public RequestStatusEnum TransactionStatus { get; set; } = RequestStatusEnum.Bekliyor;
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsRefunded { get; set; } = false;
        public DateTime? RefundDate { get; set; }
    }
}
