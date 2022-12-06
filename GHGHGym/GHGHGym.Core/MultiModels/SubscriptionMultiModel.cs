using GHGHGym.Core.Models.Subscriptions;

namespace GHGHGym.Core.MultiModels
{
    public class SubscriptionMultiModel
    {
        public SubscriptionViewModel SubscriptionDto { get; set; } = null!;
        public IEnumerable<SubscriptionTypeViewModel>? SubscriptionTypesDto { get; set; } = null!;
    }
}
