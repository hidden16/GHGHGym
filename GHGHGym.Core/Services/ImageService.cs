using GHGHGym.Core.Contracts;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Services
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> imageRepository;
        public ImageService(IRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task<Image> AddImage(string imageUrl)
        {
            Image image = new Image()
            {
                ImageUrl = imageUrl
            };
            await imageRepository.AddAsync(image);
            await imageRepository.SaveChangesAsync();
            return image;
        }

        public async Task<List<Image>> AddImages(ICollection<string> imageUrls)
        {
            List<Image> imagesToAdd = new List<Image>();
            foreach (var url in imageUrls)
            {
                imagesToAdd.Add(new Image()
                {
                    ImageUrl = url
                });
            }
            await imageRepository.AddRangeAsync(imagesToAdd);
            await imageRepository.SaveChangesAsync();
            return imagesToAdd;
        }
    }
}
