using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Product;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;

namespace GHGHGym.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IImageService imageService;
        public ProductService(IRepository<Product> productRepository,
            IImageService imageService)
        {
            this.productRepository = productRepository;
            this.imageService = imageService;
        }

        public async Task AddProductAsync(AddProductViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
            };
            List<Image> images = await imageService.AddImages(model.ImageUrls);
            List<ProductImage> productsImages = new List<ProductImage>();
            foreach (var image in images)
            {
                productsImages.Add(new ProductImage()
                {
                    Product = product,
                    Image = image
                });
            }
            product.ProductsImages = productsImages;
            await productRepository.AddAsync(product);
            await productRepository.SaveChangesAsync();
        }

        public IEnumerable<ProductViewModel> All()
        {
            var products = productRepository.All()
                .Include(x=>x.ProductsImages)
                .ThenInclude(x=>x.Image)
                .ToList();
            List<ProductViewModel> productsDto = new List<ProductViewModel>();
            List<string> imageUrls = new List<string>();
            foreach (var product in products)
            {
                productsDto.Add(new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price= product.Price,
                    ImageUrls = product.ProductsImages.Select(x=>x.Image.ImageUrl).ToList()
                });
            }
            return productsDto;
        }
    }
}
