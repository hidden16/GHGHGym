using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Trainers;
using GHGHGym.Core.Services;
using GHGHGym.Infrastructure.Data;
using GHGHGym.Infrastructure.Data.Common.Repositories;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.Enums;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace GHGHGym.Tests
{
    [TestFixture]
    public class TrainerServiceTest
    {
        private ApplicationDbContext context;
        private IRepository<Trainer> trainerRepository;
        private IRepository<Image> imageRepository;
        private IRepository<ApplicationUser> userRepository;
        private IRepository<TrainerImage> trainerImageRepository;
        private IRepository<Comment> commentRepository;
        private UserManager<ApplicationUser> userManager;
        private IImageService imageService;
        private ICommentService commentService;
        private ITrainerService trainerService;

        private Guid userId;
        private ApplicationUser user;
        private Trainer trainer;

        [SetUp]
        public async Task SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("CategoryDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            trainerRepository = new Repository<Trainer>(context);
            imageRepository = new Repository<Image>(context);
            userRepository = new Repository<ApplicationUser>(context);
            trainerImageRepository = new Repository<TrainerImage>(context);
            commentRepository = new Repository<Comment>(context);
            //mocking user manager
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            userManagerMock.Setup(t => t.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock.Setup(t => t.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"))
                .ReturnsAsync(IdentityResult.Success);

            imageService = new ImageService(imageRepository);
            commentService = new CommentService(commentRepository);

            // user creation
            userId = Guid.Parse("ff524168-c8de-41a8-9d0c-5d1c69741de2");
            user = new ApplicationUser()
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

            //FindByIdAsync method mock (UserManager)

            userManagerMock.Setup(t => t.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(user);
            trainerService = new TrainerService(trainerRepository, imageService, userManagerMock.Object, userRepository, commentService, trainerImageRepository);
            // trainer creation
            trainer = new Trainer
            {
                Id = Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85c12"),
                ApplicationUserId = userId,
                Description = "testtt",
                EmailAddress = "testtt@abv.bg",
                FirstName = "vanko",
                LastName = "oknav",
                InstagramLink = "testtt",
                FacebookLink = "testtt",
                PhoneNumber = "testtt",
                TwitterLink = "testtt"
            };

            await trainerRepository.AddAsync(trainer);
            await trainerRepository.SaveChangesAsync();
        }

        [Test]
        public async Task Test_BecomeTrainerAsync()
        {
            List<string> imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            AddTrainerViewModel model = new AddTrainerViewModel
            {
                Description = "testt",
                EmailAddress = "test2@abv.bg",
                FirstName = "George",
                LastName = "egroeG",
                InstagramLink = "www.test.com",
                FacebookLink = "ww.test.com",
                TwitterLink = "w.test.com",
                ImageUrls = imageUrls
            };

            await trainerService.BecomeTrainerAsync(model, userId);

            var userTest = await userRepository.GetByIdAsync(userId);

            Assert.IsNotNull(userTest.TrainerId);

            var trainers = trainerRepository.All();

            //2 because in set up 1 is added
            Assert.AreEqual(2, trainers.Count());
        }
        [Test]
        public async Task Test_GetTrainerIdByUserIdAsync()
        {
            var trainerReturned = await trainerService.GetTrainerIdByUserIdAsync(userId);

            Assert.AreEqual(trainer.Id.ToString(), trainerReturned);

            var trainerReturnedNull = await trainerService.GetTrainerIdByUserIdAsync(Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85222"));

            Assert.AreEqual(null, trainerReturnedNull);
        }
        [Test]
        public async Task Test_AllTrainersAsync()
        {
            Trainer trainer2 = new Trainer
            {
                Id = Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85112"),
                ApplicationUserId = userId,
                Description = "Description",
                EmailAddress = "testtt@abv.bg",
                FirstName = "vanko",
                LastName = "oknav",
                InstagramLink = "InstagramLink",
                FacebookLink = "FacebookLink",
                PhoneNumber = "PhoneNumber",
                TwitterLink = "TwitterLink"
            };
            await trainerRepository.AddAsync(trainer2);
            await trainerRepository.SaveChangesAsync();

            var trainers = await trainerService.AllTrainersAsync(userId.ToString());

            Assert.AreEqual(2, trainers.Count());
        }
        [Test]
        public async Task Test_GetTrainerById()
        {
            var trainerById = trainerService.GetTrainerById(Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85c12"));

            Assert.IsNotNull(trainerById);
            Assert.AreEqual(trainer.Description, trainerById.TrainerDto.Description);
        }
        [Test]
        public async Task Test_GetForEditAsync()
        {
           var trainerForEdit = await trainerService.GetForEditAsync(Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85c12"));

            Assert.IsNotNull(trainerForEdit);
            Assert.AreEqual(trainer.Description, trainerForEdit.Description);

            var trainerForEditNull = await trainerService.GetForEditAsync(Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85912"));
            Assert.IsNull(trainerForEditNull);
        }
        [Test]
        public async Task Test_EditAsync()
        {
            AddTrainerViewModel model = new AddTrainerViewModel
            {
                Id = Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85c12"),
                Description = "edited test",
                EmailAddress = "testtt@abv.bg",
                FirstName = "vanko",
                LastName = "oknav",
                InstagramLink = "testtt",
                FacebookLink = "testtt",
                PhoneNumber = "testtt",
                TwitterLink = "testtt"
            };

            await trainerService.EditAsync(model);

            var editedTrainer =
                await trainerRepository.GetByIdAsync(Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85c12"));

            Assert.AreEqual(model.Description, editedTrainer.Description);
        }

        [Test]
        public async Task Test_QuitBeingTrainer()
        {
            user.TrainerId = Guid.Parse("1efe68c3-a80c-418b-b22d-91ab43c85c12");
            await userRepository.SaveChangesAsync();

            await trainerService.QuitBeingTrainerAsync(user.Id.ToString());

            Assert.AreEqual(null, trainer.FirstName);
            Assert.AreEqual(null, trainer.LastName);
            Assert.AreEqual(null, trainer.EmailAddress);
        }
        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
