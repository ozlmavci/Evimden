using Evimden.CoreLayer.DTOs.ProductDTOs;

namespace Evimden.UI.Web.Models.VMs.ProductVMs
{
    public class GetProductVM
    {
        public ProductDto Product { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }
}
