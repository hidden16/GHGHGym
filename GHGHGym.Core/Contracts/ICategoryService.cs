using GHGHGym.Core.Models.Categories;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Contracts
{
    public interface ICategoryService
    {
        public IEnumerable<Category> AllCategories();
        public IEnumerable<Task<Category>> AllMainCategoryAsync();
        public IEnumerable<Task<Category>> AllCategoryAsync();

        public Task AddCategoryAsync(CategoryViewModel model);
    }
}
