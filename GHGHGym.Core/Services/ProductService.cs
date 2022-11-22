﻿using GHGHGym.Core.Contracts;
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
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IImageService imageService;
        public ProductService(IRepository<Product> productRepository,
            IRepository<ApplicationUser> userRepository,
            IImageService imageService)
        {
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.imageService = imageService;
        }

        public async Task AddProductAsync(AddProductViewModel model)
        {
            Product product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
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
                await imageService.SetDeletedRangeByUrls(product.ProductsImages.Select(x => x.Image.ImageUrl));
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


            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
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

        public async Task<ProductMultiModel> GetProductById(Guid productId)
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
                    PurchaseProductDto = new PurchaseProductViewModel()
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
