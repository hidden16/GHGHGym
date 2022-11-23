﻿using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Categories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private IRepository<Category> categoryRepo;

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
            foreach (var category in categoryRepo.All())
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
    }
}
