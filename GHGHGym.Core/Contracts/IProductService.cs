using GHGHGym.Core.Models.Product;

namespace GHGHGym.Core.Contracts
{
    public interface IProductService
    {
        public Task AddProductAsync(ProductViewModel model);
    }
}
