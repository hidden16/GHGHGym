using GHGHGym.Core.Models.TrainingPrograms;
using GHGHGym.Core.MultiModels;

namespace GHGHGym.Core.Contracts
{
    public interface ITrainingProgramService
    {
        public Task AddProgramAsync(CreateTrainingProgramViewModel model, Guid userId);
        public Task<IEnumerable<TrainingProgramViewModel>> GetProgramsByTrainerIdAsync(Guid trainerId);
        public Task<IEnumerable<TrainingProgramViewModel>> GetProgramsByTrainerIdWithDeletedAsync(Guid trainerId);
        public Task<EditTrainingProgramViewModel> GetProgramForEdit(Guid programId);
        public Task Edit(EditTrainingProgramViewModel model);
        public Task Delete(Guid programId);
        public Task Restore(Guid programId);
    }
}
