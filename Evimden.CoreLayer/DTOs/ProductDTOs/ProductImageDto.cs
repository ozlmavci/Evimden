using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evimden.CoreLayer.DTOs.ProductDTOs
{
    public class ProductImageDto : BaseDto
    {
        public Guid ProductImageId { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? SavedFileName { get; set; }
    }
}
