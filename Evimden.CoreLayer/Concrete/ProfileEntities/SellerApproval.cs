using Evimden.CoreLayer.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Evimden.CoreLayer.Concrete.ProfileEntities
{
    public class SellerApproval : BaseEntity
    {
        [Key]
        public Guid SellerApprovalId{ get; set; }
        public Guid SellerId { get; set; }
        public RequestStatusEnum ApprovalStatus { get; set; } = RequestStatusEnum.Bekliyor;

        public Seller Seller { get; set; }
    }
}
