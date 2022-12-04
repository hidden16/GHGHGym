using GHGHGym.Core.Models.Categories;
namespace GHGHGym.Core.Contracts
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryListViewModel> AllCategories();
        public IEnumerable<CategoryListViewModel> AllWithDeletedCategories();
        public Task AddCategoryAsync(CategoryViewModel model);
        public Task<EditCategoryViewModel> GetForEditAsync(Guid id);
        public Task EditAsync(EditCategoryViewModel model);
        public Task SetDeletedAsync(Guid id);
        public Task RestoreAsync(Guid id);
    }
}
