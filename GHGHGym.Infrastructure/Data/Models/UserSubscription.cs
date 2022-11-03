using GHGHGym.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class UserSubscription
    {
        public Guid UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; } = null!;

        public Guid SubscriptionId { get; set; }
        [Required]
        public Subscription Subscription { get; set; } = null!;

        public Guid SubscriptionTypeId { get; set; }
        [Required]
        public SubscriptionType SubscriptionType { get; set; } = null!;

        [Required]
        public DateTime SubscriptionStartDate { get; set; }
        [Required]
        public DateTime SubscriptionEndDate { get; set; }
    }
}
