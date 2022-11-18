using GHGHGym.Core.Models.Product;

namespace GHGHGym.Core.Contracts
{
    public interface IProductService
    {
        public Task AddProductAsync(AddProductViewModel model);
        public IEnumerable<ProductViewModel> All();
    }
}
