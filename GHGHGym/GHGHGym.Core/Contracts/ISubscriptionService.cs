using GHGHGym.Core.Models.Subscriptions;

namespace GHGHGym.Core.Contracts
{
    public interface ISubscriptionService
    {
        public IEnumerable<SubscriptionTypeViewModel> AllWithTrainerSubscriptionTypes();
        public Task SubscribeAsync(SubscriptionViewModel model, Guid userId);
        public Task<bool> IsUserSubscribedAsync(Guid userId);
    }
}
