using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;

namespace GHGHGym.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var categoryList = categoryService.AllCategories()
                .Where(x => x.Type != SubCategory);
            var model = new CategoryViewModel()
            {
                ParentCategories = categoryList
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await categoryService.AddCategoryAsync(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = categoryService.AllCategories();
            return View(model);
        }
    }
}
