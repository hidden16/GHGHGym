using GHGHGym.Core.Models.TrainingPrograms;
using GHGHGym.Core.MultiModels;

namespace GHGHGym.Core.Contracts
{
    public interface ITrainingProgramService
    {
        public Task AddProgramAsync(CreateTrainingProgramViewModel model, Guid userId);
        public Task<IEnumerable<TrainingProgramViewModel>> GetProgramsByTrainerIdAsync(Guid trainerId);
    }
}
