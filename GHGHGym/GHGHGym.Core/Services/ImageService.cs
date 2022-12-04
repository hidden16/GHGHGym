using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Services
{
    // service is being used in other services not controllers
    public class ImageService : IImageService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly IRepository<Image> imageRepository;
        public ImageService(IRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task<Image> AddImage(string imageUrl)
        {
            Image image = new Image()
            {
                ImageUrl = sanitizer.Sanitize(imageUrl)
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
                    ImageUrl = sanitizer.Sanitize(url)
                });
            }
            await imageRepository.AddRangeAsync(imagesToAdd);
            await imageRepository.SaveChangesAsync();
            return imagesToAdd;
        }

        public async Task<List<Guid>> SetDeletedRangeByUrls(IEnumerable<string> imageUrls)
        {
            var images = imageRepository.All();
            var imagesToDelete = new List<Image>();
            var imageIdsToReturn = new List<Guid>();
            foreach (var image in images)
            {
                if (imageUrls.Any(x => x == image.ImageUrl))
                {
                    imageIdsToReturn.Add(image.Id);
                    imagesToDelete.Add(image);
                }
            }
            imageRepository.SetDeletedRange(imagesToDelete);
            await imageRepository.SaveChangesAsync();
            return imageIdsToReturn;
        }
    }
}
