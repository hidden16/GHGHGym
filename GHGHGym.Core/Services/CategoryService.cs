using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Categories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task AddCategoryAsync(CategoryViewModel model)
        {
            await categoryRepo.AddAsync(new Category()
            {
                Name = model.Name,
                ParentCategoryId = model.ParentCategoryId,
                CategoryType = model.CategoryType
            });
            await categoryRepo.SaveChangesAsync();
        }

        public IEnumerable<Category> AllCategories()
        {
            return categoryRepo.All();
        }

        public IEnumerable<Task<Category>> AllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task<Category>> AllMainCategoryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
