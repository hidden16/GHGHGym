﻿using Ganss.Xss;
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
        public TrainingProgramService(IRepository<TrainingProgram> trainingProgramRepository,
            IImageService imageService,
            ITrainerService trainerService)
        {
            this.trainingProgramRepository = trainingProgramRepository;
            this.imageService = imageService;
            this.trainerService = trainerService;
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
            return await trainingProgramRepository.All()
                .Where(x => x.TrainerId == trainerId)
                .Include(x => x.TrainingProgramImages)
                .ThenInclude(x => x.Image)
                .Select(x => new TrainingProgramViewModel()
                {
                    TrainerId = x.TrainerId,
                    Name = x.Name,
                    ProgramDescription = x.ProgramDescription,
                    ImageUrls = x.TrainingProgramImages
                    .Select(x => x.Image.ImageUrl.ToString())
                    .ToList()
                })
                .ToListAsync();
        }
    }
}
