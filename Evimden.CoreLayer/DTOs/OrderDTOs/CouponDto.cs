namespace Evimden.CoreLayer.DTOs.OrderDTOs
{
    public class CouponDto : BaseDto
    {
        public Guid CouponId { get; set; }
        public Guid UserId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Rate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsUsed { get; set; }
    }
}
