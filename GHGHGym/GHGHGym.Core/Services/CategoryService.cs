using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Categories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GHGHGym.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly IRepository<Category> categoryRepo;

        public CategoryService(IRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task AddCategoryAsync(CategoryViewModel model)
        {
            await categoryRepo.AddAsync(new Category()
            {
                Name = sanitizer.Sanitize(model.Name),
                ParentCategoryId = model.ParentCategoryId,
                CategoryType = model.CategoryType
            });
            await categoryRepo.SaveChangesAsync();
        }

        public IEnumerable<CategoryListViewModel> AllCategories()
        {
            List<CategoryListViewModel> categoriesModel = new List<CategoryListViewModel>();
            foreach (var category in categoryRepo.All().Include(x => x.ParentCategory))
            {
                categoriesModel.Add(new CategoryListViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Type = category.CategoryType.ToString()
                });
            }
            return categoriesModel;
        }

        public IEnumerable<CategoryListViewModel> AllWithDeletedCategories()
        {
            List<CategoryListViewModel> categoriesModel = new List<CategoryListViewModel>();
            foreach (var category in categoryRepo.AllWithDeleted().Include(x => x.ParentCategory))
            {
                categoriesModel.Add(new CategoryListViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Type = category.CategoryType.ToString(),
                    IsDeleted = category.IsDeleted.ToString() ?? null
                });
            }
            return categoriesModel;
        }

        public async Task EditAsync(EditCategoryViewModel model)
        {
            var category = await categoryRepo.GetByIdAsync(model.CategoryId);
            category.Name = model.Name;
            category.CategoryType = model.CategoryType;
            category.ParentCategoryId = model.ParentCategoryId;
            category.ModifiedOn = DateTime.UtcNow;
            categoryRepo.Update(category);
            await categoryRepo.SaveChangesAsync();
        }

        public async Task<EditCategoryViewModel> GetForEditAsync(Guid id)
        {
            try
            {
                var model = await categoryRepo.GetByIdAsync(id);

                var categoryToReturn = new EditCategoryViewModel()
                {
                    CategoryId = model.Id,
                    CategoryType = model.CategoryType,
                    Name = model.Name,
                    ParentCategoryId = model.ParentCategoryId,
                };
                return categoryToReturn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task RestoreAsync(Guid id)
        {
            var category = await categoryRepo.GetByIdAsync(id);
            categoryRepo.Undelete(category);
            await categoryRepo.SaveChangesAsync();
        }

        public async Task SetDeletedAsync(Guid id)
        {
            await categoryRepo.SetDeletedByIdAsync(id);
            await categoryRepo.SaveChangesAsync();
        }
    }
}
