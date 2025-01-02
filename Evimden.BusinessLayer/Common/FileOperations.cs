using Microsoft.AspNetCore.Http;

namespace Evimden.BusinessLayer.Common
{
    public static class FileOperations
    {
        public static async Task<string> SaveImageAsync(IFormFile image, Guid id, bool isForProduct)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    throw new ArgumentException("Invalid image file.");
                }

                if (id == Guid.Empty)
                {
                    throw new ArgumentException("Invalid seller id.");
                }

                string uploadPath;
                if (isForProduct)
                {
                    uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "images", id.ToString(), "products");
                }
                else
                {
                    uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "images", id.ToString());
                }

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                var fileName = Path.GetFileNameWithoutExtension(image.FileName);
                var extension = Path.GetExtension(image.FileName);
                var newFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadPath, newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
