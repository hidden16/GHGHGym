using GHGHGym.Core.Models.TrainingPrograms;

namespace GHGHGym.Core.Contracts
{
    public interface ITrainingProgramService
    {
        public Task AddProgramAsync(CreateTrainingProgramViewModel model, Guid userId);
    }
}
