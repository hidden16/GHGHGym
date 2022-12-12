using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Linq;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Comments;
using GHGHGym.Core.Models.Product;
using GHGHGym.Core.MultiModels;
using GHGHGym.Core.Services;
using GHGHGym.Core.Services.EmailSender.Models;
using GHGHGym.Infrastructure.Data;
using GHGHGym.Infrastructure.Data.Common.Repositories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.Enums;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GHGHGym.Tests
{
    public class ProductServiceTest
    {
        private ApplicationDbContext context;
        private IRepository<Product> productRepository;
        private IRepository<ApplicationUser> userRepository;
        private IRepository<Image> imageRepository;
        private IRepository<Comment> commentRepository;
        private IImageService imageService;
        private ICommentService commentService;
        private IProductService productService;
        private IRepository<ProductImage> productImageRepository;
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CategoryDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            productRepository = new Repository<Product>(context);
            userRepository = new Repository<ApplicationUser>(context);
            productImageRepository = new Repository<ProductImage>(context);
            imageRepository = new Repository<Image>(context);
            commentRepository = new Repository<Comment>(context);
            imageService = new ImageService(imageRepository);
            commentService = new CommentService(commentRepository);
            productService = new ProductService(productRepository, userRepository, commentService, imageService, productImageRepository);
        }

        [Test]
        public async Task Test_AddProduct()
        {
            List<string> imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            AddProductViewModel model = new AddProductViewModel()
            {
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                ImageUrls = imageUrls,
                Price = 20m
            };

            await productService.AddProductAsync(model);

            var products = productRepository.All();

            Assert.AreEqual(1, products.Count());
        }
        [Test]
        public async Task Test_All()
        {
            var nullProducts = productService.All();
            Assert.AreEqual(null, nullProducts);

            List<string> imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            AddProductViewModel model = new AddProductViewModel()
            {
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                ImageUrls = imageUrls,
                Price = 20m
            };

            await productService.AddProductAsync(model);

            var products = productService.All();

            Assert.AreEqual(1, products.Count());
        }
        [Test]
        public async Task Test_Edit()
        {
            Product model = new Product()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"),
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                Price = 20m,
            };

            await productRepository.AddAsync(model);
            await productRepository.SaveChangesAsync();

            List<string> imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            AddProductViewModel editModel = new AddProductViewModel()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"),
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196b22"),
                Description = "Edited test",
                Name = "edited name",
                Price = 35m,
                ImageUrls = imageUrls
            };
            await productService.EditAsync(editModel);

            var product = await productRepository.GetByIdAsync(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));
            Assert.AreEqual("Edited test", product.Description);
        }
        [Test]
        public async Task Test_GetForEditAsync()
        {
            var nullProduct = await productService.GetForEditAsync(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));

            Assert.AreEqual(null, nullProduct);

            Product model = new Product()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"),
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                Price = 20m
            };

            await productRepository.AddAsync(model);
            await productRepository.SaveChangesAsync();

            var product = await productService.GetForEditAsync(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));

            Assert.AreEqual("testt", product.Name);
        }
        [Test]
        public async Task Test_GetProductById()
        {
            var nullProduct = productService.GetProductById(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));

            Assert.AreEqual(null, nullProduct);

            Product model = new Product()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"),
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                Price = 20m
            };

            await productRepository.AddAsync(model);
            await productRepository.SaveChangesAsync();

            var product = productService.GetProductById(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));

            Assert.AreEqual("testt", product.ProductDto.Name);
        }
        [Test]
        public async Task Test_Purchase()
        {
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");

            var user = new ApplicationUser()
            {
                Id = userId,
                Email = "test@abv.bg",
                FirstName = "Ivan",
                LastName = "Ivan",
                Gender = GenderType.Male,
                BirthDate = DateTime.UtcNow,
                UserName = "IvanIvan",
            };
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();

            Product model = new Product()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"),
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                Price = 20m
            };

            await productRepository.AddAsync(model);
            await productRepository.SaveChangesAsync();

            List<string> imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            ProductMultiModel multiModel = new ProductMultiModel()
            {
                ProductDto = new ProductViewModel()
                {
                    Id = model.Id,
                    Description = model.Description,
                    Price = model.Price,
                    Name = model.Name,
                    ImageUrls = imageUrls
                },
                Comments = null,
                PurchaseProductDto = new PurchaseProductViewModel()
                {
                    Quantity = 1
                }
            };
            await productService.PurchaseAsync(multiModel, userId);

            var appUser = await userRepository.All()
                .Where(x=>x.Id == userId)
                .Include(x=>x.PurchasedProducts)
                .FirstOrDefaultAsync();

            Assert.AreEqual(1, appUser.PurchasedProducts.Count);
        }

        [Test]
        public async Task Test_SetDeleted()
        {
            Product model = new Product()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"),
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                Price = 20m,
                IsDeleted = false,
            };

            await productRepository.AddAsync(model);
            await productRepository.SaveChangesAsync();

            await productService.SetDeletedAsync(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));

            var product = await productRepository.GetByIdAsync(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));

            Assert.AreEqual(true, product.IsDeleted);
        }
         [Test]
        public async Task Test_AllWithDeleted()
        {
            var nullProducts = productService.AllWithDeleted();

            Assert.AreEqual(null, nullProducts);

            Product model = new Product()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"),
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                Price = 20m,
                IsDeleted = true
            };

            await productRepository.AddAsync(model);
            await productRepository.SaveChangesAsync();

            Product model2 = new Product()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3222"),
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                Price = 20m,
                IsDeleted = false
            };

            await productRepository.AddAsync(model2);
            await productRepository.SaveChangesAsync();

            var products = productService.AllWithDeleted();

            Assert.AreEqual(2, products.Count());
        }
        [Test]
        public async Task Test_Restore()
        {
            Product model = new Product()
            {
                Id = Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"),
                Name = "testt",
                CategoryId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68"),
                Description = "Test description",
                Price = 20m,
                IsDeleted = true
            };

            await productRepository.AddAsync(model);
            await productRepository.SaveChangesAsync();

            await productService.RestoreAsync(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));

            var product = await productRepository.GetByIdAsync(Guid.Parse("d330925e-2262-4ad1-b26c-e48a9d5a3161"));
            Assert.AreEqual(false, product.IsDeleted);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
