using Microsoft.AspNetCore.Http;

namespace GHGHGym.Core.Services.CloudinaryService.Contracts
{
    public interface ICloudinaryService
    {
        Task<string> UploadPhotoAsync(IFormFile file, string fileName);
    }
}
