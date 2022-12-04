using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Comments;
using GHGHGym.Core.Models.Product;
using GHGHGym.Core.MultiModels;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;

namespace GHGHGym.Core.Services
{
    public class ProductService : IProductService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IImageService imageService;
        private readonly ICommentService commentService;
        private readonly IRepository<ProductImage> productImageRepository;
        public ProductService(IRepository<Product> productRepository,
            IRepository<ApplicationUser> userRepository,
            ICommentService commentService,
            IImageService imageService,
            IRepository<ProductImage> productImageRepository)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.imageService = imageService;
            this.commentService = commentService;
            this.productImageRepository = productImageRepository;
        }

        public async Task AddProductAsync(AddProductViewModel model)
        {
            Product product = new Product()
            {
                Name = sanitizer.Sanitize(model.Name),
                Price = model.Price,
                Description = sanitizer.Sanitize(model.Description),
            };
            List<Image> images = await imageService.AddImages(model.ImageUrls);
            List<ProductImage> productsImages = new List<ProductImage>();
            foreach (var image in images)
            {
                productsImages.Add(new ProductImage()
                {
                    Product = product,
                    Image = image
                });
            }
            product.ProductsImages = productsImages;
            await productRepository.AddAsync(product);
            await productRepository.SaveChangesAsync();
        }

        public IEnumerable<ProductViewModel> All()
        {
            var products = productRepository.AllReadonly()
                .Include(x => x.ProductsImages)
                .ThenInclude(x => x.Image)
                .ToList();
            if (products == null)
            {
                return null;
            }
            List<ProductViewModel> productsDto = new List<ProductViewModel>();
            List<string> imageUrls = new List<string>();
            foreach (var product in products.Where(x=>x.IsDeleted == false))
            {
                productsDto.Add(new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrls = product.ProductsImages
                    .Where(x => !x.IsDeleted)
                    .Select(x => x.Image.ImageUrl)
                    .ToList()
                });
            }
            return productsDto;
        }

        public async Task Edit(AddProductViewModel model)
        {
            var product = productRepository.AllReadonly()
                .Where(x => x.Id == model.Id)
                .Include(x => x.ProductsImages)
                .ThenInclude(x => x.Image)
                .FirstOrDefault();

            if (model.ImageUrls.Count() != 0)
            {
                var imagesId = await imageService.SetDeletedRangeByUrls(product.ProductsImages.Select(x => x.Image.ImageUrl));
                foreach (var id in imagesId)
                {
                    var productImageToDelete = await productImageRepository.GetByIdsAsync(new object[] {model.Id, id});
                    productImageRepository.SetDeleted(productImageToDelete);
                }
                List<Image> images = await imageService.AddImages(model.ImageUrls);
                List<ProductImage> productsImages = new List<ProductImage>();
                foreach (var image in images)
                {
                    productsImages.Add(new ProductImage()
                    {
                        Product = product,
                        Image = image
                    });
                }
                product.ProductsImages = productsImages;
            }


            product.Name = sanitizer.Sanitize(model.Name);
            product.Price = model.Price;
            product.Description = sanitizer.Sanitize(model.Description);
            product.CategoryId = model.CategoryId;

            productRepository.Update(product);
            await productRepository.SaveChangesAsync();
        }

        public async Task<AddProductViewModel> GetForEditAsync(Guid productId)
        {
            try
            {
                var product = await productRepository.GetByIdAsync(productId);

                var productToReturn = new AddProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                };

                return productToReturn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ProductMultiModel GetProductById(Guid productId)
        {
            try
            {
                var product = productRepository.AllReadonly()
                    .Where(x => x.Id == productId)
                    .Include(x => x.ProductsImages)
                    .ThenInclude(x => x.Image)
                    .FirstOrDefault();

                var productToReturn = new ProductViewModel()
                {
                    Id = product.Id,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrls = product.ProductsImages
                    .Where(x => !x.Image.IsDeleted)
                    .Select(x => x.Image.ImageUrl)
                    .ToList()
                };

                var multiModel = new ProductMultiModel()
                {
                    ProductDto = productToReturn,
                    PurchaseProductDto = new PurchaseProductViewModel(),
                    Comments = commentService.GetCommentByProductId(product.Id),
                };
                return multiModel;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public async Task Purchase(ProductMultiModel model, Guid userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            var product = await productRepository.GetByIdAsync(model.ProductDto.Id);
            for (int i = 0; i < model?.PurchaseProductDto?.Quantity; i++)
            {
                user.PurchasedProducts.Add(new UserProduct()
                {
                    ApplicationUser = user,
                    Product = product
                });
            }
            await userRepository.SaveChangesAsync();
        }

        public async Task SetDeleted(Guid productId)
        {
            await productRepository.SetDeletedByIdAsync(productId);
            await productRepository.SaveChangesAsync();
        }
    }
}
