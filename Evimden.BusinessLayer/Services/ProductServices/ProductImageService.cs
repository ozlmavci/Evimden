using AutoMapper;
using Evimden.BusinessLayer.Common;
using Evimden.BusinessLayer.Interfaces.ProductInterfaces;
using Evimden.CoreLayer.Concrete.ProductEntities;
using Evimden.CoreLayer.DTOs.ProductDTOs;
using Evimden.CoreLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Evimden.BusinessLayer.Services.ProductServices
{
    public class ProductImageService : Service<ProductImage, ProductImageDto>, IProductImageService
    {
        public ProductImageService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProductImage> logger) : base(unitOfWork, mapper, logger)
        {
        }

        /// <summary>
        /// Ürün görselini kayıt eder ve döner.
        /// </summary>
        /// <param name="productImageDto"></param>
        /// <param name="sellerId"></param>
        /// <returns></returns>
        public async Task<ProductImageDto> AddProductImageAsync(ProductImageDto productImageDto, Guid sellerId)
        {
            try
            {
                if (productImageDto.Image != null)
                {
                    var imagePath = await FileOperations.SaveImageAsync(productImageDto.Image, sellerId, true);
                    productImageDto.ImagePath = imagePath;
                    productImageDto.SavedFileName = Path.GetFileName(imagePath);
                    return await AddAsync(productImageDto);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddProductImageAsync: Görsel kayıt edilemedi. Error: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Ürün görsellerini kayıt eder ve döner.
        /// </summary>
        /// <param name="productImageDtos"></param>
        /// <param name="sellerId"></param>
        /// <returns></returns>
        public async Task<List<ProductImageDto>> AddRangeProductImagesAsync(List<ProductImageDto> productImageDtos, Guid sellerId)
        {
            try
            {
                var productImages = new List<ProductImageDto>();
                foreach (var productImageDto in productImageDtos)
                {
                    if (productImageDto.Image != null)
                    {
                        var addedDto = await AddProductImageAsync(productImageDto, sellerId);
                        productImages.Add(addedDto);
                    }
                }
                return productImages;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AddProductImagesAsync: Görseller kayıt edilemedi. Error: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Ürün görsellerini ürün idsine göre döner.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<ProductImageDto>> GetProductImagesByProductId(Guid productId)
        {
            try
            {
                var productImages = await _unitOfWork.Repository<ProductImage>().Where(x => x.ProductId == productId).ToListAsync();
                if (!productImages.Any())
                {
                    _logger.LogWarning($"GetProductImagesByProductId: {productId} id'li ürün için görsel bulunamadı.");
                    return null;
                }
                return _mapper.Map<List<ProductImageDto>>(productImages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetProductImagesByProductId: Görseller listelenemedi. Error: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Ürün görselini siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteImageById(Guid id)
        {
            try
            {
                var image = await GetByIdAsync(id);
                if (image != null)
                {
                    var filePath = image.ImagePath;
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    await DeleteAsync(id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DeleteImageById: Görsel silinemedi. Error: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Ürün görsellerini siler.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task DeleteImagesByProductId(Guid productId)
        {
            try
            {
                var images = await _unitOfWork.Repository<ProductImage>().Where(x => x.ProductId == productId).ToListAsync();
                if (images.Any())
                {
                    foreach (var image in images)
                    {
                        var filePath = image.ImagePath;
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                    DeleteRange(_mapper.Map<List<ProductImageDto>>(images));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"DeleteImagesByProductId: Görseller silinemedi. Error: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Görselin veritabanında kayıtlı olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public async Task<bool> IsExist(string imagePath)
        {
            return await _unitOfWork.Repository<ProductImage>().AnyAsync(x => x.ImagePath == imagePath);
        }
    }
}
