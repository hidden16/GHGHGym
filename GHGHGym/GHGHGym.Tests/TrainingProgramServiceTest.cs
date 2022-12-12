using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Trainers;
using GHGHGym.Core.Models.TrainingPrograms;
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
using Moq;
using NUnit.Framework;

namespace GHGHGym.Tests
{
    [TestFixture]
    public class TrainingProgramServiceTest
    {
        private ApplicationDbContext context;
        private IRepository<TrainingProgram> trainingProgramRepository;
        private IRepository<Trainer> trainerRepository;
        private IRepository<TrainingProgramImage> trainingProgramImageRepository;
        private IRepository<Image> imageRepository;
        private IRepository<ApplicationUser> userRepository;
        private IRepository<Comment> commentRepository;
        private IRepository<TrainerImage> trainerImageRepository;
        private IImageService imageService;
        private ICommentService commentService;
        private ITrainerService trainerService;
        private ITrainingProgramService trainingProgramService;

        private Guid userId;
        private ApplicationUser user;
        private List<string> imageUrls;
        private AddTrainerViewModel trainerModel;
        private IQueryable<Trainer>? trainer;
        private Guid trainerId;
        private TrainingProgram program;

        [SetUp]
        public async Task SetUp()
        {
            // InMemoryDb initializing
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TrainingProgramDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            // Repository initializing
            trainingProgramRepository = new Repository<TrainingProgram>(context);
            trainerRepository = new Repository<Trainer>(context);
            trainingProgramImageRepository = new Repository<TrainingProgramImage>(context);
            imageRepository = new Repository<Image>(context);
            userRepository = new Repository<ApplicationUser>(context);
            commentRepository = new Repository<Comment>(context);
            trainerImageRepository = new Repository<TrainerImage>(context);

            //mocking user manager
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            // Service initializing
            imageService = new ImageService(imageRepository);
            commentService = new CommentService(commentRepository);
            trainerService = new TrainerService(trainerRepository, imageService, userManagerMock.Object, userRepository, commentService, trainerImageRepository);
            trainingProgramService = new TrainingProgramService(trainingProgramRepository, imageService, trainerService, trainerRepository, trainingProgramImageRepository);

            // Creating user
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

            imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            trainerModel = new AddTrainerViewModel
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

            await trainerService.BecomeTrainerAsync(trainerModel, userId);

            trainer = trainerRepository.All();

            trainerId = await trainer.Select(x => x.Id).FirstOrDefaultAsync();

            program = new TrainingProgram
            {
                Id = Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8088"),
                Name = "test",
                ProgramDescription = "test",
                TrainerId = trainerId
            };

            await trainingProgramRepository.AddAsync(program);
            await trainingProgramRepository.SaveChangesAsync();
        }

        [Test]
        public async Task Test_AddProgramAsync()
        {
            List<string> imageUrls = new List<string>()
            {
                "test1.jpg",
                "test2.jpg",
                "test3.jpg"
            };
            AddTrainerViewModel trainerModel = new AddTrainerViewModel
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

            await trainerService.BecomeTrainerAsync(trainerModel, userId);

            var trainer = trainerRepository.All();

            var trainerId = await trainer.Select(x => x.Id).FirstOrDefaultAsync();

            CreateTrainingProgramViewModel model = new CreateTrainingProgramViewModel
            {
                Name = "test",
                ProgramDescription = "testt",
                TrainerId = trainerId
            };

            await trainingProgramService.AddProgramAsync(model, userId);

            var trainingPrograms = trainingProgramRepository.All();

            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await trainingProgramService.AddProgramAsync(model, Guid.Parse("4bbc757e-ba10-4993-901b-da23f8625bdb"));
            });
            // 2 because 1 is added in set up
            Assert.AreEqual(2, trainingPrograms.Count());
        }
        [Test]
        public async Task Test_GetProgramsByTrainerIdAsync()
        {
            var programs = await trainingProgramService.GetProgramsByTrainerIdAsync(trainerId);

            Assert.AreEqual(1, programs.Count());
        }

        [Test]
        public async Task Test_GetProgramForEdit()
        {
            var programForEdit =
                await trainingProgramService.GetProgramForEdit(Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8088"));
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                var programForEditError =
                    await trainingProgramService.GetProgramForEdit(Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8000"));
            });

            Assert.AreEqual(program.ProgramDescription, programForEdit.ProgramDescription);
        }

        [Test]
        public async Task Test_Edit()
        {
            EditTrainingProgramViewModel model = new EditTrainingProgramViewModel
            {
                Id = Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8088"),
                Name = "Edited name",
                ProgramDescription = "testt",
                TrainerId = trainerId
            };

            await trainingProgramService.Edit(model);

            var editedTrainingProgram = await trainingProgramRepository.GetByIdAsync(program.Id);

            Assert.AreEqual(model.Name, editedTrainingProgram.Name);
        }

        [Test]
        public async Task Test_Delete()
        {
            await trainingProgramService.Delete(Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8088"));

            var deletedPrograms = trainingProgramRepository.AllWithDeleted();

            var deletedProgram = await deletedPrograms.Select(x => x.IsDeleted).FirstOrDefaultAsync();

            Assert.AreEqual(true, deletedProgram);
        }

        [Test]
        public async Task Test_GetProgramsByTrainerIdWithDeletedAsync()
        {

            TrainingProgram program2 = new TrainingProgram
            {
                Id = Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8000"),
                Name = "test",
                ProgramDescription = "test",
                TrainerId = trainerId,
                IsDeleted = true
            };

            await trainingProgramRepository.AddAsync(program2);
            await trainingProgramRepository.SaveChangesAsync();

            var programs = await trainingProgramService.GetProgramsByTrainerIdWithDeletedAsync(trainerId);

            Assert.AreEqual(2, programs.Count());
        }

        [Test]
        public async Task Test_Restore()
        {
            TrainingProgram program2 = new TrainingProgram
            {
                Id = Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8128"),
                Name = "test",
                ProgramDescription = "test",
                TrainerId = trainerId,
                IsDeleted = true
            };
            await trainingProgramRepository.AddAsync(program2);
            await trainingProgramRepository.SaveChangesAsync();

            await trainingProgramService.Restore(Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8128"));

            var undeletedProgram =
                await trainingProgramRepository.GetByIdAsync(Guid.Parse("06fa6bfb-a911-486d-a68f-49cd921c8128"));

            Assert.AreEqual(false, undeletedProgram.IsDeleted);
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
