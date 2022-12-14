using Ganss.Xss;
using GHGHGym.Core.Contracts;
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
        // anti xss
        private HtmlSanitizer sanitizer = new HtmlSanitizer();

        private readonly IRepository<Trainer> trainerRepository;
        private readonly IImageService imageService;
        private readonly ICommentService commentService;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IRepository<TrainerImage> trainerImageRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public TrainerService(IRepository<Trainer> trainerRepository,
            IImageService imageService,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> userRepository,
            ICommentService commentService,
            IRepository<TrainerImage> trainerImageRepository)
        {
            this.trainerRepository = trainerRepository;
            this.imageService = imageService;
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.commentService = commentService;
            this.trainerImageRepository = trainerImageRepository;
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

            if (model.ImageUrls.Count != 0)
            {
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
            }

            var user = await userRepository.GetByIdAsync(userId);
            await userManager.AddToRoleAsync(user, "Trainer");

            await trainerRepository.AddAsync(trainer);
            user.TrainerId = trainer.Id;
            await trainerRepository.SaveChangesAsync();
        }

        public async Task<string> GetTrainerIdByUserIdAsync(Guid userId)
        {
            var trainer = await trainerRepository.All()
                .Where(x => x.ApplicationUserId == userId)
                .FirstOrDefaultAsync();
            if (trainer != null)
            {
                return trainer.Id.ToString();
            }
            return null;
        }

        public async Task<IEnumerable<ShowTrainerViewModel>> AllTrainersAsync(string? userId)
        {
            ApplicationUser user = null;
            List<ShowTrainerViewModel> trainers;
            if (userId != null)
            {
                user = await userRepository.GetByIdAsync(Guid.Parse(userId));
                trainers = await trainerRepository.All()
                    .Include(x => x.TrainerPrograms)
                    .Include(x => x.TrainersImages)
                    .ThenInclude(x => x.Image)
                    .Select(x => new ShowTrainerViewModel()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Id = x.Id,
                        ImageUrls = x.TrainersImages.Select(x => x.Image.ImageUrl).ToList(),
                        TrainingProgramsCount = x.TrainerPrograms.Where(x => !x.IsDeleted).Count(),
                        UserTrainerId = user.TrainerId ?? null
                    }).ToListAsync();
            }
            else
            {
                trainers = await trainerRepository.All()
               .Include(x => x.TrainerPrograms)
               .Include(x => x.TrainersImages)
               .ThenInclude(x => x.Image)
               .Select(x => new ShowTrainerViewModel()
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   Id = x.Id,
                   ImageUrls = x.TrainersImages.Select(x => x.Image.ImageUrl).ToList(),
                   TrainingProgramsCount = x.TrainerPrograms.Where(x => !x.IsDeleted).Count(),
               }).ToListAsync();
            }
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
                Comments = commentService.GetCommentByTrainerId(trainer.Id)
            };

            return model;
        }

        public async Task<AddTrainerViewModel> GetForEditAsync(Guid trainerId)
        {
            try
            {
                var product = await trainerRepository.GetByIdAsync(trainerId);

                var productToReturn = new AddTrainerViewModel()
                {
                    Id = product.Id,
                    EmailAddress = product.EmailAddress,
                    FirstName = product.FirstName,
                    LastName = product.LastName,
                    FacebookLink = product.FacebookLink,
                    InstagramLink = product.InstagramLink,
                    PhoneNumber = product.PhoneNumber,
                    TwitterLink = product.TwitterLink,
                    Description = product.Description
                };

                return productToReturn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task EditAsync(AddTrainerViewModel model)
        {
            var trainer = await trainerRepository.All()
                .Where(x => x.Id == model.Id)
                .Include(x => x.TrainersImages)
                .ThenInclude(x => x.Image)
                .FirstOrDefaultAsync();

            if (model.ImageUrls.Count() != 0)
            {
                var imagesId = await imageService.SetDeletedRangeByUrls(trainer.TrainersImages.Select(x => x.Image.ImageUrl));
                foreach (var id in imagesId)
                {
                    var trainerImageToDelete = await trainerImageRepository.GetByIdsAsync(new object[] { id, trainer.Id });
                    trainerImageRepository.SetDeleted(trainerImageToDelete);
                }
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
            }

            trainer.FirstName = Sanitize(model.FirstName);
            trainer.LastName = Sanitize(model.LastName);
            trainer.PhoneNumber = Sanitize(model.PhoneNumber);
            trainer.InstagramLink = Sanitize(model.InstagramLink);
            trainer.FacebookLink = Sanitize(model.FacebookLink);
            trainer.TwitterLink = Sanitize(model.TwitterLink);
            trainer.EmailAddress = Sanitize(model.EmailAddress);
            trainer.Description = Sanitize(model.Description);
            trainer.ModifiedOn = DateTime.UtcNow;

            trainerRepository.Update(trainer);
            await trainerRepository.SaveChangesAsync();
        }

        public async Task QuitBeingTrainerAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            var trainer = await trainerRepository.All()
                .Where(x => x.ApplicationUserId == user.Id)
                .FirstOrDefaultAsync();

            user.TrainerId = null;
            userRepository.Update(user);
            trainer.FirstName = null;
            trainer.LastName = null;
            trainer.EmailAddress = null;
            trainer.PhoneNumber = null;
            trainer.Description = "";
            trainer.FacebookLink = null;
            trainer.InstagramLink = null;
            trainer.TwitterLink = null;
            trainer.ApplicationUserId = null;
            trainerRepository.SetDeleted(trainer);
            trainerRepository.Update(trainer);
            await trainerRepository.SaveChangesAsync();
            await userManager.RemoveFromRoleAsync(user, "Trainer");
        }

        private string Sanitize(string input)
        {
            return sanitizer.Sanitize(input);
        }
    }
}
