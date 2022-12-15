using GHGHGym.Core.Models.Trainers;
using GHGHGym.Core.MultiModels;

namespace GHGHGym.Core.Contracts
{
    public interface ITrainerService
    {
        public Task BecomeTrainerAsync(AddTrainerViewModel model, Guid userId);
        public Task<string> GetTrainerIdByUserIdAsync(Guid userId);
        public TrainerMultiModel GetTrainerById(Guid trainerId);
        public Task<IEnumerable<ShowTrainerViewModel>> AllTrainersAsync(string? userId);
        public Task<AddTrainerViewModel> GetForEditAsync(Guid trainerId);
        public Task EditAsync(AddTrainerViewModel model);
        public Task QuitBeingTrainerAsync(string userId);

    }
}
