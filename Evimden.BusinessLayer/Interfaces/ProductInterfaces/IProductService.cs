using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.DTOs.ProductDTOs;

namespace Evimden.BusinessLayer.Interfaces.ProductInterfaces
{
    public interface IProductService : IService<Product, ProductDto>
    {
        Task<List<ProductWithImagesDto>> GetAllProductsWithImagesAsync();
        Task<ProductWithImagesDto> GetProductWithImagesAsync(Guid productId);
        Task<List<ProductWithImagesDto>> GetProductsWithImagesByCategoryIdAsync(Guid categoryId);
        Task<List<ProductWithImagesDto>> GetProductsWithImagesBySellerIdAsync(Guid sellerId);
        Task<List<ProductWithImagesDto>> GetAllProductsWithImagesForCustomerAsync();
        Task<List<ProductWithImagesDto>> GetProductsWithImagesByCategoryIdForCustomerAsync(Guid categoryId);
        Task<ProductWithImagesDto> GetProductWithImagesForCustomerAsync(Guid productId);
        Task<List<ProductWithImagesDto>> GetProductsWithImagesBySellerIdForCustomerAsync(Guid sellerId);
        Task<bool> IsMyProduct(Guid productId, Guid sellerId);

    }
}
