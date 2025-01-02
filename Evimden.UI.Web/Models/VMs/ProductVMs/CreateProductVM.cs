using Evimden.CoreLayer.DTOs.ProductDTOs;

namespace Evimden.UI.Web.Models.VMs.ProductVMs
{
    public class CreateProductVM
    {
        public ProductWithImagesDto ProductWithImages { get; set; }
        public ProductApprovalDto ProductApprovalDto { get; set; }
    }
}
