using GHGHGym.Core.Models.Subscriptions;

namespace GHGHGym.Core.Contracts
{
    public interface ISubscriptionService
    {
        public IEnumerable<SubscriptionTypeViewModel> AllWithTrainerSubscriptionTypes();
    }
}
