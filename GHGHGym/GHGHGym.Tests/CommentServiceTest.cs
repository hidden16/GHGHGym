using System;
using System.Linq;
using System.Threading.Tasks;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Comments;
using GHGHGym.Core.Services;
using GHGHGym.Infrastructure.Data;
using GHGHGym.Infrastructure.Data.Common.Repositories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace GHGHGym.Tests
{
    [TestFixture]
    public class CommentServiceTest
    {
        private ApplicationDbContext context;
        private IRepository<Comment> repo;
        private ICommentService commentService;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CommentDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            repo = new Repository<Comment>(context);
            commentService = new CommentService(repo);
        }

        [Test]
        public void Test_AddProductComment()
        {
            var commentText = "test";
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
            var productId = Guid.Parse("3290f6d6-c887-4924-9713-4c18c6dc6475");

            commentService.AddProductComment(commentText, userId, productId);

            var comments = repo.All();

            Assert.AreEqual(1, comments.Count());
        }
        [Test]
        public void Test_GetCommentByProductId()
        {
            var commentText = "test";
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
            var productId = Guid.Parse("3290f6d6-c887-4924-9713-4c18c6dc6475");
            IRepository<ApplicationUser> userRepository = new Repository<ApplicationUser>(context);
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
            userRepository.Add(user);
            userRepository.SaveChanges();

            Comment comment = new Comment()
            {
                Id = Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"),
                Text = commentText,
                ApplicationUserId = userId,
                ProductId = productId
            };

            repo.Add(comment);
            repo.SaveChanges();

            var model = commentService.GetCommentByProductId(Guid.Parse("3290f6d6-c887-4924-9713-4c18c6dc6475"));

            Assert.AreEqual(1, model.Count());

            Comment comment2 = new Comment()
            {
                Id = Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991444"),
                Text = commentText,
                ApplicationUserId = userId,
                ProductId = productId
            };
            repo.Add(comment2);
            repo.SaveChanges();
            var model2 = commentService.GetCommentByProductId(Guid.Parse("3290f6d6-c887-4924-9713-4c18c6dc6475"));
            Assert.AreEqual(2, model2.Count());

        }
        [Test]
        public async Task Test_DeleteCommentAsync()
        {
            var commentText = "test";
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
            var productId = Guid.Parse("3290f6d6-c887-4924-9713-4c18c6dc6475");

            Comment comment = new Comment()
            {
                Id = Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"),
                Text = commentText,
                ApplicationUserId = userId,
                ProductId = productId
            };

            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();

            await commentService.DeleteCommentAsync(Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"));

            var model = await repo.GetByIdAsync(Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"));

            Assert.AreEqual(true, model.IsDeleted);
        }
        [Test]
        public async Task Test_Edit()
        {
            var commentText = "test";
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
            var productId = Guid.Parse("3290f6d6-c887-4924-9713-4c18c6dc6475");

            Comment comment = new Comment()
            {
                Id = Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"),
                Text = commentText,
                ApplicationUserId = userId,
                ProductId = productId
            };

            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();

            EditCommentViewModel editModel = new EditCommentViewModel()
            {
                Text = "Edited test",
                CommentId = comment.Id
            };

            await commentService.Edit(editModel);

            var model = await repo.GetByIdAsync(Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"));

            Assert.AreEqual("Edited test", model.Text);

            editModel.CommentId = Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991444");
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await commentService.Edit(editModel);
            });
        }
        [Test]
        public async Task Test_CheckCommentUserBeforeEditAsync()
        {
            var commentText = "test";
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
            var productId = Guid.Parse("3290f6d6-c887-4924-9713-4c18c6dc6475");

            Comment comment = new Comment()
            {
                Id = Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"),
                Text = commentText,
                ApplicationUserId = userId,
                ProductId = productId
            };

            await repo.AddAsync(comment);
            await repo.SaveChangesAsync();

            var isUserTrue = await commentService.CheckCommentUserBeforeEditAsync(Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"), userId);

            Assert.That(true, Is.EqualTo(isUserTrue));

            var userIdFalse = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de9");
            var isUserFalse = await commentService.CheckCommentUserBeforeEditAsync(Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"), userIdFalse);

            Assert.That(false, Is.EqualTo(isUserFalse));
        }
        [Test]
        public void Test_GetCommentByTrainerId()
        {
            var commentText = "test";
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
            var trainerId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68");

            IRepository<ApplicationUser> userRepository = new Repository<ApplicationUser>(context);
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
            userRepository.Add(user);
            userRepository.SaveChanges();

            Comment comment = new Comment()
            {
                Id = Guid.Parse("f68a8af3-ec4a-4e69-9307-881cf7991888"),
                Text = commentText,
                ApplicationUserId = userId,
                TrainerId = trainerId
            };
            repo.Add(comment);
            repo.SaveChanges();

            var commentByTrainer = commentService.GetCommentByTrainerId(trainerId);

            Assert.AreEqual(1, commentByTrainer.Count());
        }
        [Test]
        public void Test_AddTrainerComment()
        {
            var commentText = "test";
            var userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
            var trainerId = Guid.Parse("4fbea684-a34e-4f5b-9838-058853196a68");

            commentService.AddTrainerComment(commentText, userId, trainerId);

            var comments = repo.All();

            Assert.AreEqual(1, comments.Count());
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
