using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Services;
using GHGHGym.Infrastructure.Data;
using GHGHGym.Infrastructure.Data.Common.Repositories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GHGHGym.Tests
{
    [TestFixture]
    public class ImageServiceTest
    {
        private ApplicationDbContext context;
        private IRepository<Image> repo;
        private IImageService imageService;
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ImageDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            repo = new Repository<Image>(context);
            imageService = new ImageService(repo);
        }

        [Test]
        public async Task Test_AddImage()
        {
            var imageUrl = "testtesttesttest.jpg";
            var image = await imageService.AddImage(imageUrl);

            Assert.IsNotNull(image);

            var images = repo.All();
            Assert.AreEqual(1, images.Count());
        }
        [Test]
        public async Task Test_AddImages()
        {
            List<string> imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            var image = await imageService.AddImages(imageUrls);

            Assert.IsNotNull(image);

            var images = repo.All();
            Assert.AreEqual(3, images.Count());
        }
        [Test]
        public async Task Test_SetDeletedRangeByUrls()
        {
            List<string> imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            var image = await imageService.AddImages(imageUrls);

            await imageService.SetDeletedRangeByUrls(imageUrls);

            var images = repo.All();
            bool isNotDeleted = false;
            foreach (var deletedImage in images)
            {
                if (deletedImage.IsDeleted == false)
                {
                    isNotDeleted = true;
                }
            }

            Assert.IsFalse(isNotDeleted);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
