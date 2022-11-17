using GHGHGym.Core.Models.Product;
using static GHGHGym.Infrastructure.Constants.RoleConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GHGHGym.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        [HttpGet]
        [Authorize(Roles = Administrator)]
        public IActionResult Add()
        {
            var model = new ProductViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Administrator)]
        public IActionResult Add(ProductViewModel model)
        {
            return Ok();
        }
    }
}
