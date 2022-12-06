using GHGHGym.Infrastructure.Abstractions.Contracts;
using GHGHGym.Infrastructure.Data.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class UserSubscription : IDeletableEntity
    {
        public Guid UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; } = null!;

        public Guid SubscriptionId { get; set; }
        [Required]
        public Subscription Subscription { get; set; } = null!;
        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
        [Required]
        public DateTime SubscriptionStartDate { get; set; }
        [Required]
        public DateTime SubscriptionEndDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
