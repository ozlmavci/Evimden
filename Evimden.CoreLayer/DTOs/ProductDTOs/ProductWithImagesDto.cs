namespace Evimden.CoreLayer.DTOs.ProductDTOs
{
    public class ProductWithImagesDto
    {
        public ProductDto Product { get; set; }
        public List<ProductImageDto> Images { get; set; }
    }
}
