using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Subscriptions;
using GHGHGym.Core.Models.Trainers;
using GHGHGym.Core.MultiModels;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GHGHGym.Core.Services
{
    public class TrainerService : ITrainerService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly IRepository<Trainer> trainerRepository;
        private readonly IImageService imageService;
        private readonly ICommentService commentService;
        private readonly ISubscriptionService subscriptionService;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public TrainerService(IRepository<Trainer> trainerRepository,
            IImageService imageService,
            ISubscriptionService subscriptionService,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> userRepository,
            ICommentService commentService)
        {
            this.trainerRepository = trainerRepository;
            this.imageService = imageService;
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.commentService = commentService;
            this.subscriptionService = subscriptionService;
        }
        public async Task BecomeTrainerAsync(AddTrainerViewModel model, Guid userId)
        {
            Trainer trainer = new Trainer()
            {
                ApplicationUserId = userId,
                Description = Sanitize(model.Description),
                EmailAddress = Sanitize(model.EmailAddress),
                FirstName = Sanitize(model.FirstName),
                LastName = Sanitize(model.LastName),
                InstagramLink = Sanitize(model.InstagramLink ?? ""),
                FacebookLink = Sanitize(model.FacebookLink ?? ""),
                PhoneNumber = Sanitize(model.PhoneNumber ?? ""),
                TwitterLink = Sanitize(model.TwitterLink ?? ""),
            };

            List<Image> images = await imageService.AddImages(model.ImageUrls);
            List<TrainerImage> trainerImages = new List<TrainerImage>();
            foreach (var image in images)
            {
                trainerImages.Add(new TrainerImage()
                {
                    Trainer = trainer,
                    Image = image
                });
            }
            trainer.TrainersImages = trainerImages;

            var user = await userRepository.GetByIdAsync(userId);
            await userManager.AddToRoleAsync(user, "Trainer");

            await trainerRepository.AddAsync(trainer);
            user.TrainerId = trainer.Id;
            await trainerRepository.SaveChangesAsync();
        }

        public string GetTrainerIdByUserId(Guid userId)
        {
            var trainer = trainerRepository.All()
                .Where(x => x.ApplicationUserId == userId)
                .FirstOrDefault();
            if (trainer != null)
            {
                return trainer.Id.ToString();
            }
            return null;
        }

        private string Sanitize(string input)
        {
            return sanitizer.Sanitize(input);
        }

        public IEnumerable<ShowTrainerViewModel> AllTrainers()
        {
            var trainers = trainerRepository.All()
                .Include(x => x.TrainerPrograms)
                .Include(x => x.TrainersImages)
                .ThenInclude(x => x.Image)
                .Select(x => new ShowTrainerViewModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Id = x.Id,
                    ImageUrls = x.TrainersImages.Select(x => x.Image.ImageUrl).ToList(),
                    TrainingProgramsCount = x.TrainerPrograms.Count()
                });
            return trainers;
        }

        public TrainerMultiModel GetTrainerById(Guid trainerId)
        {
            var trainer = trainerRepository.All()
                .Where(x => x.Id == trainerId)
                .Include(x => x.TrainersImages)
                .ThenInclude(x => x.Image)
                .Include(x => x.TrainerPrograms)
                .FirstOrDefault();

            TrainerViewModel trainerModel = new TrainerViewModel()
            {
                Id = trainer.Id,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                Description = trainer.Description,
                EmailAddress = trainer.EmailAddress,
                FacebookLink = trainer.FacebookLink,
                InstagramLink = trainer.InstagramLink,
                TwitterLink = trainer.TwitterLink,
                ImageUrls = trainer.TrainersImages
                            .Where(x => !x.Image.IsDeleted)
                            .Select(x => x.Image.ImageUrl)
                            .ToList()
            };

            TrainerMultiModel model = new TrainerMultiModel()
            {
                TrainerDto = trainerModel,
                SubscriptionTypesDto = subscriptionService.AllWithTrainerSubscriptionTypes(),
                Comments = commentService.GetCommentByTrainerId(trainer.Id)
            };

            return model;
        }
    }
}
