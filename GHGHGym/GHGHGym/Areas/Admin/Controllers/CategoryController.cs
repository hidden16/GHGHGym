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
            var model = categoryService.AllWithDeletedCategories();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await categoryService.GetForEditAsync(id);
            model.ParentCategories = categoryService.AllCategories()
               .Where(x => x.Type != SubCategory)
               .ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel model)
        {
            model.ParentCategories = categoryService.AllCategories()
               .Where(x => x.Type == SubCategory)
               .ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await categoryService.EditAsync(model);
            }
            catch (Exception)
            {
                return View(model);
            }
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await categoryService.SetDeletedAsync(id);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                await categoryService.RestoreAsync(id);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }
    }
}
