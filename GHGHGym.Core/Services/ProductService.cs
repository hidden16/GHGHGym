using GHGHGym.Core.Contracts;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Services
{
    public class ProductService : IProductService
    {
        private IRepository<Product> repository;
        public ProductService(IRepository<Product> repository)
        {
            this.repository = repository;
        }
        public Task AddProductAsync()
        {
            repository.AddAsync(new Product()
            {

            });
            return Task.CompletedTask;
        }
    }
}
