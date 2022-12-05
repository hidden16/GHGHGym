using GHGHGym.Core.Models.Trainers;
using GHGHGym.Core.MultiModels;

namespace GHGHGym.Core.Contracts
{
    public interface ITrainerService
    {
        public Task BecomeTrainerAsync(AddTrainerViewModel model, Guid userId);
        public string GetTrainerIdByUserId(Guid userId);
        public TrainerMultiModel GetTrainerById(Guid trainerId);
        public IEnumerable<ShowTrainerViewModel> AllTrainers();
    }
}
