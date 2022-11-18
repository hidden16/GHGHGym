using GHGHGym.Core.Models.Product;
using static GHGHGym.Infrastructure.Constants.RoleConstants;
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
        private readonly ICloudinaryService cloudinaryService;
        public ProductController(IProductService productService,
            ICloudinaryService cloudinaryService)
        {
            this.productService = productService;
            this.cloudinaryService = cloudinaryService;
        }
        [HttpGet]
        [Authorize(Roles = Administrator)]
        public IActionResult Add()
        {
            var model = new AddProductViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = Administrator)]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            List<string> imageUrls = new List<string>();
            foreach (var file in model.Files)
            {
                if (file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".jpeg"))
                {
                    var result = await cloudinaryService.UploadPhotoAsync(file, file.FileName.ToString());
                    imageUrls.Add(result);
                }
            }
            model.ImageUrls = imageUrls;

            await productService.AddProductAsync(model);
            return Ok();
        }

        [HttpGet]
        public IActionResult All()
        {
            var entities = productService.All();
            return View(entities);
        }
    }
}
