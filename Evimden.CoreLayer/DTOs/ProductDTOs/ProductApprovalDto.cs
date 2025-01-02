using Evimden.CoreLayer.Common.Enums;

namespace Evimden.CoreLayer.DTOs.ProductDTOs
{
    public class ProductApprovalDto : BaseDto
    {
        public Guid ProductApprovalId { get; set; }
        public Guid ProductId { get; set; }
        public Guid SellerId { get; set; }
        public RequestStatusEnum RequestStatus { get; set; } = RequestStatusEnum.Bekliyor;
    }
}
