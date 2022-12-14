using GHGHGym.Core.Contracts;
using GHGHGym.Core.MultiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static GHGHGym.Core.Constants.MessageConstant;

namespace GHGHGym.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult All()
        {
            var entities = productService.All();
            if (entities == null)
            {
                return View();
            }
            return View(entities);
        }
        [Authorize]
        public async Task<IActionResult> Purchase(ProductMultiModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var userId = User?.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
                await productService.PurchaseAsync(model, Guid.Parse(userId));
                if (model?.PurchaseProductDto?.Quantity > 1)
                {
                    TempData[SuccessMessage] = "Successfully purchased products!";
                }
                else
                {
                    TempData[SuccessMessage] = "Successfully purchased product!";
                }
                return RedirectToAction(nameof(All));
            }
            catch (ArgumentNullException)
            {
                ModelState.AddModelError("", "Invalid id");
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ProductById(Guid productId)
        {
            try
            {
                var entity = productService.GetProductById(productId);
                if (entity == null)
                {
                    return RedirectToAction("All", "Product");
                }
                return View(entity);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(All));
            }
        }
    }
}
