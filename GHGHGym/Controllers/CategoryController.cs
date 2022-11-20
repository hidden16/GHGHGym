using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Categories;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;
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
            var categoryList = categoryService.AllCategories()
                .Where(x=>x.Type != SubCategory);
            var model = new CategoryViewModel()
            {
                ParentCategories = categoryList
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await categoryService.AddCategoryAsync(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
