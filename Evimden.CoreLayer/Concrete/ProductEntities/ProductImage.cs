using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evimden.CoreLayer.Concrete.ProductEntities
{
    public class ProductImage : BaseEntity
    {
        public Guid ProductImageId { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? SavedFileName { get; set; }
        public Product Product { get; set; } //Bir ürün görseli yanlızca tek ürüne aittir.
    }
}   
