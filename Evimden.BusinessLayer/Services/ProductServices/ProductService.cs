using AutoMapper;
using Evimden.BusinessLayer.Interfaces.ProductInterfaces;
using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.DTOs.ProductDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Evimden.BusinessLayer.Services.ProductServices
{
    public class ProductService : Service<Product, ProductDto>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Product> logger) : base(unitOfWork, mapper, logger)
        {
        }

        public async Task<bool> IsMyProduct(Guid productId, Guid sellerId)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(productId);
            return product.SellerId == sellerId;
        }

        #region GET PRODUCT OPERATIONS

        /// <summary>
        /// Tüm ürünleri fotoğrafları ile getirir.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductWithImagesDto>> GetAllProductsWithImagesAsync()
        {
            var products = await _unitOfWork.Repository<Product>()
               .GetAll()
               .Include(p => p.Images)
               .ToListAsync();

            return _mapper.Map<List<ProductWithImagesDto>>(products);
        }

        /// <summary>
        /// Ürünü fotoğrafı ile id'sine göre getirir.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductWithImagesDto> GetProductWithImagesAsync(Guid productId)
        {
            var product = await _unitOfWork.Repository<Product>().GetAll()
               .Include(p => p.Images)
               .FirstOrDefaultAsync(p => p.ProductId == productId);

            return _mapper.Map<ProductWithImagesDto>(product);
        }

        /// <summary>
        /// Belirtilen kategori ID'sine göre ürünleri fotoğraflarıyla birlikte getirir.
        /// </summary>
        /// <param name="categoryId">Filtreleme için kullanılacak kategori ID'si.</param>
        /// <returns>Kategoriye ait ürünlerin fotoğraflarıyla birlikte DTO listesi.</returns>
        public async Task<List<ProductWithImagesDto>> GetProductsWithImagesByCategoryIdAsync(Guid categoryId)
        {
            var products = await _unitOfWork.Repository<Product>()
                .GetAll()
                .Include(p => p.Images)
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
          
            return _mapper.Map<List<ProductWithImagesDto>>(products);
        }


        /// <summary>
        /// Satıcı ID'sine göre ürünleri fotoğrafları ile getirir.
        /// </summary>
        /// <param name="sellerId"></param>
        /// <returns></returns>
        public async Task<List<ProductWithImagesDto>> GetProductsWithImagesBySellerIdAsync(Guid sellerId)
        {
            var products = await _unitOfWork.Repository<Product>()
                .GetAll()
                .Include(p => p.Images)
                .Where(p => p.SellerId == sellerId) // Satıcı ID'sine göre filtreleme
                .ToListAsync();

            return _mapper.Map<List<ProductWithImagesDto>>(products);
        }

        #endregion


        #region MAGAZADA GORUNECEK URUNLER

        public async Task<List<ProductWithImagesDto>> GetAllProductsWithImagesForCustomerAsync()
        {
            try
            {
                var productsWithImages = await GetAllProductsWithImagesAsync();
                if (!productsWithImages.Any())
                {
                    _logger.LogWarning("GetAllProductsWithImagesForCustomerAsync: Mağazada görünecek ürünler bulunamadı.");
                    return null;
                }
                return productsWithImages.Where(p => p.Product.IsVisiable).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetAllProductsWithImagesForCustomerAsync: Mağazada görünecek ürünler getirilemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<List<ProductWithImagesDto>> GetProductsWithImagesByCategoryIdForCustomerAsync(Guid categoryId)
        {
            try
            {
                var productsWithImages = await GetProductsWithImagesByCategoryIdAsync(categoryId);
                if (!productsWithImages.Any())
                {
                    _logger.LogWarning("GetProductsWithImagesByCategoryIdForCustomerAsync: Mağazada görünecek ürünler bulunamadı.");
                    return null;
                }
                return productsWithImages.Where(p => p.Product.IsVisiable).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetProductsWithImagesByCategoryIdForCustomerAsync: Mağazada görünecek ürünler getirilemedi. Hata: {ex.Message}");
                throw ex;
            }

        }

        public async Task<ProductWithImagesDto> GetProductWithImagesForCustomerAsync(Guid productId)
        {
            try
            {
                var productWithImages = await GetProductWithImagesAsync(productId);
                if (!productWithImages.Product.IsVisiable)
                {
                    _logger.LogWarning($"GetProductWithImagesForCustomerAsync: {productId} id'li ürün mağazada görünür değil.");
                    return null;
                }
                return productWithImages;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetProductWithImagesForCustomerAsync: {productId} id'li ürün getirilemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        public async Task<List<ProductWithImagesDto>> GetProductsWithImagesBySellerIdForCustomerAsync(Guid sellerId)
        {
            try
            {
                var productsWithImages = await GetProductsWithImagesBySellerIdAsync(sellerId);
                if (!productsWithImages.Any())
                {
                    _logger.LogWarning($"GetProductsWithImagesBySellerIdForCustomerAsync: {sellerId} id'li satıcı için mağazada görünecek ürünler bulunamadı.");
                    return null;
                }
                return productsWithImages.Where(p => p.Product.IsVisiable).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetProductsWithImagesBySellerIdForCustomerAsync: {sellerId} id'li satıcı için mağazada görünecek ürünler getirilemedi. Hata: {ex.Message}");
                throw ex;
            }
        }

        #endregion
    }
}
