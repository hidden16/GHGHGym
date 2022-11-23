using GHGHGym.Core.Models.Product;
using GHGHGym.Core.MultiModels;

namespace GHGHGym.Core.Contracts
{
    public interface IProductService
    {
        public Task AddProductAsync(AddProductViewModel model);
        public IEnumerable<ProductViewModel> All();
        public Task<ProductMultiModel> GetProductById(Guid productId);
        public Task Purchase(ProductMultiModel model, Guid userId);
        public Task<AddProductViewModel> GetForEditAsync(Guid productId);
        public Task Edit(AddProductViewModel model);
        public Task SetDeleted(Guid productId);
    }
}
