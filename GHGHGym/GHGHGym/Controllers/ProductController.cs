using GHGHGym.Core.Models.Product;
using static GHGHGym.Infrastructure.Constants.RoleConstants;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;
using static GHGHGym.Core.Constants.MessageConstant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Services.CloudinaryService.Contracts;
using System.Security.Claims;
using GHGHGym.Core.MultiModels;

namespace GHGHGym.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ICloudinaryService cloudinaryService;
        public ProductController(IProductService productService,
            ICategoryService categoryService,
            ICloudinaryService cloudinaryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.cloudinaryService = cloudinaryService;
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
