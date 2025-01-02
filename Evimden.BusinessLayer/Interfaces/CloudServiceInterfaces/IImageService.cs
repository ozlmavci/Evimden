using Evimden.CoreLayer.DTOs.ProductDTOs;

namespace Evimden.BusinessLayer.Interfaces.CloudServiceInterfaces
{
    public interface IImageService
    {
        Task UploadImage(ProductImageDto image);
        Task DeleteImage(Guid id);
    }
}
