using Evimden.CoreLayer.Concrete.IdentityEntities;

namespace Evimden.CoreLayer.Concrete.OrderEntities
{
    public class Coupon : BaseEntity
    {
        public Guid CouponId { get; set; }
        public Guid UserId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Rate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsUsed { get; set; }

        public CustomUser User { get; set; }
        public Payment Payment { get; set; }
    }
}
