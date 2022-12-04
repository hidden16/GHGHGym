using GHGHGym.Core.Models.Product;
using GHGHGym.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;
using GHGHGym.Core.Services.CloudinaryService.Contracts;

namespace GHGHGym.Areas.Admin.Controllers
{
    public class ProductController : BaseController
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
            return RedirectToAction(nameof(All));
        }
        public IActionResult All()
        {
            var entities = productService.AllWithDeleted();
            if (entities == null)
            {
                return View();
            }
            return View(entities);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await productService.GetForEditAsync(id);
            model.Categories = categoryService.AllCategories()
               .Where(x => x.Type == SubCategory)
               .ToList();
            return View(model);
        }

        [HttpPost]
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
            await productService.EditAsync(model);
            return RedirectToAction(nameof(All));
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await productService.SetDeletedAsync(id);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Invalid Id");
                return RedirectToAction(nameof(All));
            }
        }
        public async Task<IActionResult> Restore(Guid id)
        {
            await productService.RestoreAsync(id);
            return RedirectToAction(nameof(All));
        }
    }
}
