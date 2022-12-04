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
        public IActionResult All()
        {
            var categories = categoryService.AllCategories();
            return View(categories);
        }
    }
}
