using Evimden.BusinessLayer.Interfaces.CloudServiceInterfaces;
using Evimden.BusinessLayer.Interfaces.ProductInterfaces;
using Evimden.CoreLayer.DTOs.ProductDTOs;

namespace Evimden.BusinessLayer.Services.CloudServices
{
    public class ImageService : IImageService
    {
        private readonly ICloudStorageService _cloudStorageService;
        private readonly IProductImageService _productImageService;

        public ImageService(ICloudStorageService cloudStorageService, IProductImageService productImageService)
        {
            _cloudStorageService = cloudStorageService;
            _productImageService = productImageService;
        }

        public async Task UploadImage(ProductImageDto image)
        {
            if (image.ImagePath != null)
            {
                image.SavedFileName = GenerateFileNameToSave(image.Image.FileName);
                image.ImagePath = await _cloudStorageService.UploadFileAsync(image.Image, image.SavedFileName);
            }
            await _productImageService.AddAsync(image);
        }

        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmssfff")}{extension}";
        }

        public async Task DeleteImage(Guid id)
        {
            var image = await _productImageService.GetByIdAsync(id);
            if (image != null)
            {
                if (!string.IsNullOrWhiteSpace(image.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(image.SavedFileName);
                    image.SavedFileName = String.Empty;
                    image.ImagePath = String.Empty;
                }
                await _productImageService.DeleteAsync(id);
            }
        }
    }
}

