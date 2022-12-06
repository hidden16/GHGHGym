namespace GHGHGym.Core.Models.Subscriptions
{
    public class SubscriptionViewModel
    {
        public Guid SubscriptionTypeId { get; set; }
        public Guid? TrainerId { get; set; }
        public string? TrainerName { get; set; }
        public DateTime StartDate { get; set; }
    }
}
