using GHGHGym.Core.Services.CloudinaryService.Contracts;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Ganss.Xss;

namespace GHGHGym.Core.Services.CloudinaryService.Models
{
    public class CloudinaryService : ICloudinaryService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly Cloudinary cloudinary;
        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }
        public async Task<string> UploadPhotoAsync(IFormFile file, string fileName)
        {
            byte[] destinationData;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationData = memoryStream.ToArray();
            }

            UploadResult result;

            using (var memoryStream = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(sanitizer.Sanitize(fileName), memoryStream)
                };

                result = await this.cloudinary.UploadAsync(uploadParams);
            }

            return result.SecureUrl.AbsoluteUri;
        }
    }
}
