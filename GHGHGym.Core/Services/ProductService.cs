using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Product;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task AddProductAsync(ProductViewModel model)
        {
            await productRepository.AddAsync(new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ProductsImages = model.ProductImages,
                CategoryProducts = model.ProductCategories
            });
            await productRepository.SaveChangesAsync();
        }
    }
}
