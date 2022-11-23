using GHGHGym.Core.Models.Product;
using static GHGHGym.Infrastructure.Constants.RoleConstants;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;
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
        [Authorize(Roles = Administrator)]
        public IActionResult Add()
        {
            var model = new AddProductViewModel()
            {
                Categories = categoryService.AllCategories()
                .Where(x => x.Type == SubCategory)
                .ToList()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Administrator)]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            model.Categories = categoryService.AllCategories()
                .Where(x => x.Type == SubCategory)
                .ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            List<string> imageUrls = new List<string>();
            foreach (var file in model.Files)
            {
                if (file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".jpeg"))
                {
                    var result = await cloudinaryService.UploadPhotoAsync(file, file.FileName.ToString());
                    imageUrls.Add(result);
                }
                else
                {
                    ModelState.AddModelError("Files", "Files are invalid");
                    return View(model);
                }
            }
            model.ImageUrls = imageUrls;
            await productService.AddProductAsync(model);
            return RedirectToAction("Index", "Home");
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
                await productService.Purchase(model, Guid.Parse(userId));
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
        public async Task<IActionResult> ProductById(Guid Id)
        {
            try
            {
                var entity = await productService.GetProductById(Id);
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

        [HttpGet]
        [Authorize(Roles = Administrator)]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await productService.GetForEditAsync(id);
            model.Categories = categoryService.AllCategories()
               .Where(x => x.Type == SubCategory)
               .ToList();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Administrator)]
        public async Task<IActionResult> Edit(AddProductViewModel model)
        {
            model.Categories = categoryService.AllCategories()
               .Where(x => x.Type == SubCategory)
               .ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            List<string> imageUrls = new List<string>();
            foreach (var file in model.Files)
            {
                if (file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".jpeg"))
                {
                    var result = await cloudinaryService.UploadPhotoAsync(file, file.FileName.ToString());
                    imageUrls.Add(result);
                }
                else
                {
                    ModelState.AddModelError("Files", "Files are invalid");
                    return View(model);
                }
            }
            model.ImageUrls = imageUrls;
            await productService.Edit(model);
            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = Administrator)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await productService.SetDeleted(id);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Invalid Id");
                return RedirectToAction(nameof(All));
            }
        }
    }
}
