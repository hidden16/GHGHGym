using GHGHGym.Core.Models.Product;
using GHGHGym.Core.MultiModels;

namespace GHGHGym.Core.Contracts
{
    public interface IProductService
    {
        public Task AddProductAsync(AddProductViewModel model);
        public IEnumerable<ProductViewModel> All();
        public IEnumerable<ProductWithDeletedViewModel> AllWithDeleted();
        public ProductMultiModel GetProductById(Guid productId);
        public Task PurchaseAsync(ProductMultiModel model, Guid userId);
        public Task<AddProductViewModel> GetForEditAsync(Guid productId);
        public Task EditAsync(AddProductViewModel model);
        public Task SetDeletedAsync(Guid productId);
        public Task RestoreAsync(Guid productId);
    }
}
