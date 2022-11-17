using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Categories;
using GHGHGym.Infrastructure.Data.Models.Enums;
using static GHGHGym.Infrastructure.Constants.RoleConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GHGHGym.Controllers
{
    [Authorize(Roles = Administrator)]
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryViewModel()
            {
                ParentCategories = categoryService.AllCategories()
                .Where(x => x.CategoryType != CategoryType.SubCategory)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            await categoryService.AddCategoryAsync(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
