using GHGHGym.Core.Models.Categories;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Contracts
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryListViewModel> AllCategories();

        public Task AddCategoryAsync(CategoryViewModel model);
    }
}
