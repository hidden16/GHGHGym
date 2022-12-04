using GHGHGym.Core.Models.Categories;
namespace GHGHGym.Core.Contracts
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryListViewModel> AllCategories();

        public Task AddCategoryAsync(CategoryViewModel model);
    }
}
