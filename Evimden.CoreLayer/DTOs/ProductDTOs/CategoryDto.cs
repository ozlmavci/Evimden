namespace Evimden.CoreLayer.DTOs.ProductDTOs
{
    public class CategoryDto : BaseDto
    {
        public Guid CategoryId { get; set; }
        public Guid ParrentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
