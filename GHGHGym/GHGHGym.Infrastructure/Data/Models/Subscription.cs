using GHGHGym.Infrastructure.Abstractions.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Subscription : BaseDeletableModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public Guid SubscriptionTypeId { get; set; }
        [Required]
        public SubscriptionType SubscriptionType { get; set; } = null!;

        public List<UserSubscription> UsersSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
