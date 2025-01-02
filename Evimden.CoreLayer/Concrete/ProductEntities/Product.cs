using Evimden.CoreLayer.Concrete.OrderEntities;
using Evimden.CoreLayer.Concrete.ProfileEntities;

namespace Evimden.CoreLayer.Concrete.ProductEntities
{
    public class Product : BaseEntity
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

        public Category Category { get; set; } //Ürünün hangi kategoriye ait olduğunu belirtmek için.
        public Seller Seller { get; set; }

        public ProductApproval ProductApproval { get; set; }
        public List<ProductImage> Images { get; set; } // Bir ürün birden fazla görsele sahip olabilir.
        public List<Order> Orders { get; set; }
        public List<ProductCart> ProductCarts { get; set; }

    }
}

