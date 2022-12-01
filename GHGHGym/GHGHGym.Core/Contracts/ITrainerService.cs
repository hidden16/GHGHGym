using GHGHGym.Core.Models.Trainers;

namespace GHGHGym.Core.Contracts
{
    public interface ITrainerService
    {
        public Task BecomeTrainerAsync(AddTrainerViewModel model, Guid userId);
    }
}
