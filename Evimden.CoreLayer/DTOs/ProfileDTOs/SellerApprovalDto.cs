using Evimden.CoreLayer.Common.Enums;

namespace Evimden.CoreLayer.DTOs.ProfileDTOs
{
    public class SellerApprovalDto : BaseDto
    {
        public Guid SellerApprovalId { get; set; }
        public Guid SellerId { get; set; }
        public RequestStatusEnum ApprovalStatus { get; set; } = RequestStatusEnum.Bekliyor;
    }
}
