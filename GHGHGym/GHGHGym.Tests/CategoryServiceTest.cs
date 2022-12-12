using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Categories;
using GHGHGym.Core.Services;
using GHGHGym.Infrastructure.Data;
using GHGHGym.Infrastructure.Data.Common.Repositories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GHGHGym.Tests
{
    [TestFixture]
    public class CategoryServiceTest
    {
        private ApplicationDbContext context;
        private IRepository<Category> repo;
        private ICategoryService categoryService;
        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CategoryDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            repo = new Repository<Category>(context);
            categoryService = new CategoryService(repo);
        }

        [Test]
        public async Task Test_AddCategoryAsync()
        {
            CategoryViewModel model = new CategoryViewModel()
            {
                Name = "test",
                CategoryType = CategoryType.MainCategory,
                ParentCategoryId = null
            };

            await categoryService.AddCategoryAsync(model);

            var categoryCount = repo.All();
            Assert.That(categoryCount.Count() == 3);
        }

        [Test]
        public async Task Test_AllCategories()
        {

            CategoryViewModel model = new CategoryViewModel()
            {
                Name = "test",
                CategoryType = CategoryType.MainCategory,
                ParentCategoryId = null
            };
            CategoryViewModel model2 = new CategoryViewModel()
            {
                Name = "test2",
                CategoryType = CategoryType.MainCategory,
                ParentCategoryId = null
            };
            await categoryService.AddCategoryAsync(model);
            await categoryService.AddCategoryAsync(model2);

            var categoryCount = categoryService.AllCategories();
            Assert.That(4, Is.EqualTo(categoryCount.Count()));
        }
        [Test]
        public async Task Test_AllWithDeletedCategories()
        {
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                CategoryType = CategoryType.MainCategory,
                IsDeleted = true
            };
            Category category2 = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                CategoryType = CategoryType.MainCategory,
                IsDeleted = false
            };

            await repo.AddAsync(category);
            await repo.AddAsync(category2);
            await repo.SaveChangesAsync();

            var categoryCount = categoryService.AllWithDeletedCategories();
            Assert.That(4, Is.EqualTo(categoryCount.Count()));
        }
        [Test]
        public async Task Test_EditAsync()
        {
            Category category = new Category()
            {
                Id = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"),
                Name = "Test",
                CategoryType = CategoryType.MainCategory,
                IsDeleted = false
            };
            var beforeEditName = category.Name;
            await repo.AddAsync(category);
            await repo.SaveChangesAsync();

            EditCategoryViewModel editModel = new EditCategoryViewModel()
            {
                CategoryId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"),
                CategoryType = CategoryType.MainCategory,
                Name = "Edited Test",
                ParentCategoryId = null
            };

            await categoryService.EditAsync(editModel);
            var afterEditName = category.Name;
            Assert.AreNotEqual(beforeEditName, afterEditName);
            Assert.AreEqual("Edited Test", afterEditName);
            Assert.AreEqual("Test", beforeEditName);
        }
        [Test]
        public async Task Test_GetForEditAsync()
        {
            Category category = new Category()
            {
                Id = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"),
                Name = "Test",
                CategoryType = CategoryType.MainCategory,
                IsDeleted = false
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();

            var model = await categoryService.GetForEditAsync(Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"));
            Assert.AreEqual(Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"), model.CategoryId);
            Assert.AreEqual(null, await categoryService.GetForEditAsync(Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de4")));
        }
        [Test]
        public async Task Test_RestoreAsync()
        {
            Category category = new Category()
            {
                Id = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"),
                Name = "Test",
                CategoryType = CategoryType.MainCategory,
                IsDeleted = true
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();

            await categoryService.RestoreAsync(Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"));
            var model = await repo.GetByIdAsync(Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"));
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                var model2 = await repo.GetByIdAsync(Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de5"));
            });
            Assert.That(false, Is.EqualTo(model.IsDeleted));
        }
        [Test]
        public async Task Test_SetDeletedAsync()
        {
            Category category = new Category()
            {
                Id = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"),
                Name = "Test",
                CategoryType = CategoryType.MainCategory,
                IsDeleted = false
            };

            await repo.AddAsync(category);
            await repo.SaveChangesAsync();

            await categoryService.SetDeletedAsync(Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"));
            var model = await repo.GetByIdAsync(Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2"));
            Assert.That(true, Is.EqualTo(model.IsDeleted));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}