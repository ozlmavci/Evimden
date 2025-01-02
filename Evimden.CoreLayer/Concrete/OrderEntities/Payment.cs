using Evimden.CoreLayer.Concrete.ProfileEntities;

namespace Evimden.CoreLayer.Concrete.OrderEntities
{
    public class Payment : BaseEntity
    {
        public Guid PaymentId { get; set; }
        public int PaymentType { get; set; } //TODO : ENUM YAPILACAK
        public Guid PaymentInformationId { get; set; }
        public Guid? CouponId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TransactionStatus { get; set; } //TODO : ENUM YAPILACAK
        public decimal Amount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsRefunded { get; set; } = false;
        public DateTime? RefundDate { get; set; }
        public Order Order { get; set; }
        public Coupon Coupon { get; set; }
        public PaymentInformation PaymentInformation { get; set; }
    }
}
