using Microsoft.AspNetCore.Http;

namespace Evimden.BusinessLayer.Interfaces.CloudServiceInterfaces
{
    public interface ICloudStorageService
    {
        Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes = 30);
        Task<string> UploadFileAsync(IFormFile fileToUpload, string fileNameToSave);
        Task DeleteFileAsync(string fileNameToDelete);
    }
}
