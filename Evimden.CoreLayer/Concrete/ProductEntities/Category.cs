namespace Evimden.CoreLayer.Concrete.ProductEntities
{
    public class Category : BaseEntity
    {
        public Guid CategoryId { get; set; }
        public Guid ParrentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; } //Bir kategori birçok ürüne sahip olabilir.
    }
}
