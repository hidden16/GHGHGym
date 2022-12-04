using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Trainers;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.AspNetCore.Identity;

namespace GHGHGym.Core.Services
{
    public class TrainerService : ITrainerService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly IRepository<Trainer> trainerRepository;
        private readonly IImageService imageService;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public TrainerService(IRepository<Trainer> trainerRepository,
            IImageService imageService,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> userRepository)
        {
            this.trainerRepository = trainerRepository;
            this.imageService = imageService;
            this.userManager = userManager;
            this.userRepository = userRepository;
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
            await trainerRepository.SaveChangesAsync();
        }

        public string GetTrainerIdByUserId(Guid userId)
        {
            var trainer = trainerRepository.All()
                .Where(x=>x.ApplicationUserId == userId)
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
    }
}
