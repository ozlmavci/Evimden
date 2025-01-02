using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.DTOs.ProductDTOs;

namespace Evimden.BusinessLayer.Interfaces.ProductInterfaces
{
    public interface IProductImageService : IService<ProductImage, ProductImageDto>
    {
        Task<ProductImageDto> AddProductImageAsync(ProductImageDto productImageDto, Guid sellerId);
        Task<List<ProductImageDto>> AddRangeProductImagesAsync(List<ProductImageDto> productImageDtos, Guid sellerId);
        Task<List<ProductImageDto>> GetProductImagesByProductId(Guid productId);
        Task DeleteImageById(Guid id);
        Task DeleteImagesByProductId(Guid productId);
        Task<bool> IsExist(string imagePath);
    }
}
