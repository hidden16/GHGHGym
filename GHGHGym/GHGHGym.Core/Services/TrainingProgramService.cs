using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.TrainingPrograms;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;

namespace GHGHGym.Core.Services
{
    public class TrainingProgramService : ITrainingProgramService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly IRepository<TrainingProgram> trainingProgramRepository;
        private readonly IImageService imageService;
        private readonly ITrainerService trainerService;
        private readonly IRepository<Trainer> trainerRepository;
        private readonly IRepository<TrainingProgramImage> trainingProgramImageRepository;
        public TrainingProgramService(IRepository<TrainingProgram> trainingProgramRepository,
            IImageService imageService,
            ITrainerService trainerService,
            IRepository<Trainer> trainerRepository,
            IRepository<TrainingProgramImage> trainingProgramImageRepository)
        {
            this.trainingProgramRepository = trainingProgramRepository;
            this.imageService = imageService;
            this.trainerService = trainerService;
            this.trainerRepository = trainerRepository;
            this.trainingProgramImageRepository = trainingProgramImageRepository;
        }
        public async Task AddProgramAsync(CreateTrainingProgramViewModel model, Guid userId)
        {
            TrainingProgram program = new TrainingProgram()
            {
                Name = sanitizer.Sanitize(model.Name),
                ProgramDescription = sanitizer.Sanitize(model.ProgramDescription)
            };

            List<Image> images = await imageService.AddImages(model.ImageUrls);
            List<TrainingProgramImage> programImages = new List<TrainingProgramImage>();
            foreach (var image in images)
            {
                programImages.Add(new TrainingProgramImage()
                {
                    TrainingProgram = program,
                    Image = image
                });
            }
            program.TrainingProgramImages = programImages;
            var trainerId = await trainerService.GetTrainerIdByUserIdAsync(userId);
            if (trainerId == null)
            {
                throw new ArgumentException();
            }
            program.TrainerId = Guid.Parse(trainerId);
            trainingProgramRepository.Add(program);
            await trainingProgramRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrainingProgramViewModel>> GetProgramsByTrainerIdAsync(Guid trainerId)
        {
            
            var model = await trainerRepository.GetByIdAsync(trainerId);
            return await trainingProgramRepository.All()
                .Where(x => x.TrainerId == trainerId)
                .Include(x => x.TrainingProgramImages)
                .ThenInclude(x => x.Image)
                .Select(x => new TrainingProgramViewModel()
                {
                    TrainerId = x.TrainerId,
                    TrainerUserId = model.ApplicationUserId,
                    ProgramId = x.Id,
                    Name = x.Name,
                    ProgramDescription = x.ProgramDescription,
                    ImageUrls = x.TrainingProgramImages
                    .Select(x => x.Image.ImageUrl.ToString())
                    .ToList()
                })
                .ToListAsync();
        }

        public async Task<EditTrainingProgramViewModel> GetProgramForEdit(Guid programId)
        {
            return await trainingProgramRepository.All()
                .Where(x => x.Id == programId)
                .Select(x => new EditTrainingProgramViewModel()
                {
                    Name = x.Name,
                    ProgramDescription = x.ProgramDescription,
                    TrainerId = x.TrainerId,
                    Id = x.Id
                })
                .FirstAsync();
        }

        public async Task Edit(EditTrainingProgramViewModel model)
        {
            var program = await trainingProgramRepository.All()
                .Where(x=>x.Id == model.Id)
                .Include(x=>x.TrainingProgramImages)
                .ThenInclude(x=>x.Image)
                .FirstOrDefaultAsync();
            program.Name = model.Name;
            program.ProgramDescription = model.ProgramDescription;
            program.ModifiedOn = DateTime.UtcNow;
            if (model.ImageUrls.Count() != 0)
            {
                var imagesId = await imageService.SetDeletedRangeByUrls(program.TrainingProgramImages.Select(x => x.Image.ImageUrl));
                foreach (var id in imagesId)
                {
                    var trainingProgramImageToDelete = await trainingProgramImageRepository.GetByIdsAsync(new object[] { id, model.Id });
                    trainingProgramImageRepository.SetDeleted(trainingProgramImageToDelete);
                }
                List<Image> images = await imageService.AddImages(model.ImageUrls);
                List<TrainingProgramImage> trainerProgramImages = new List<TrainingProgramImage>();
                foreach (var image in images)
                {
                    trainerProgramImages.Add(new TrainingProgramImage()
                    {
                        TrainingProgram = program,
                        Image = image
                    });
                }
                program.TrainingProgramImages = trainerProgramImages;
            }

            trainingProgramRepository.Update(program);
            await trainingProgramRepository.SaveChangesAsync();
        }

        public async Task Delete(Guid programId)
        {
            await trainingProgramRepository.SetDeletedByIdAsync(programId);
            await trainingProgramRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrainingProgramViewModel>> GetProgramsByTrainerIdWithDeletedAsync(Guid trainerId)
        {
            var model = await trainerRepository.GetByIdAsync(trainerId);
            return await trainingProgramRepository.AllWithDeleted()
                .Where(x => x.TrainerId == trainerId)
                .Include(x => x.TrainingProgramImages)
                .ThenInclude(x => x.Image)
                .Select(x => new TrainingProgramViewModel()
                {
                    TrainerId = x.TrainerId,
                    TrainerUserId = model.ApplicationUserId,
                    ProgramId = x.Id,
                    Name = x.Name,
                    ProgramDescription = x.ProgramDescription,
                    IsDeleted = x.IsDeleted,
                    ImageUrls = x.TrainingProgramImages
                    .Select(x => x.Image.ImageUrl.ToString())
                    .ToList()
                })
                .ToListAsync();
        }

        public async Task Restore(Guid programId)
        {
            var program = await trainingProgramRepository.GetByIdAsync(programId);
            trainingProgramRepository.Undelete(program);
            await trainingProgramRepository.SaveChangesAsync();
        }
    }
}
