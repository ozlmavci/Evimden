namespace Evimden.CoreLayer.DTOs.ProductDTOs
{
    public class ProductDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SellerId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountRate { get; set; }
        public bool ContainGluten { get; set; }
        public bool IsVisiable { get; set; } = false;
        public bool IsApproved { get; set; } = false;
    }
}
