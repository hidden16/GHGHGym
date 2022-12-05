using GHGHGym.Core.Models.Trainers;

namespace GHGHGym.Core.Contracts
{
    public interface ITrainerService
    {
        public Task BecomeTrainerAsync(AddTrainerViewModel model, Guid userId);
        public string GetTrainerIdByUserId(Guid userId);
        public IEnumerable<ShowTrainerViewModel> AllTrainers();
    }
}
