using GHGHGym.Core.Models.Product;
using static GHGHGym.Infrastructure.Constants.RoleConstants;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Services.CloudinaryService.Contracts;

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
        public IActionResult All()
        {
            var entities = productService.All();
            return View(entities);
        }
    }
}
