using Evimden.CoreLayer.Common.Enums;

namespace Evimden.CoreLayer.Concrete.ProductEntities
{
    public class ProductApproval : BaseEntity
    {
        public Guid ProductApprovalId { get; set; }
        public Guid ProductId { get; set; }
        public Guid SellerId { get; set; }
        public RequestStatusEnum RequestStatus { get; set; } = RequestStatusEnum.Bekliyor; 
        public Product Product { get; set; } //Bir ürün onayı yanlızca tek ürüne aittir.
    }
}
