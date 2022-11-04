using GHGHGym.Infrastructure.Data.Models.Account;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Subscription
    {
        /// <summary>
        /// Id of the subscription
        /// </summary>
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Id of the subscription type
        /// </summary>
        [Required]
        [Comment("Id of the subscription")]
        public Guid SubscriptionTypeId { get; set; }
        [Required]
        public SubscriptionType SubscriptionType { get; set; } = null!;

        /// <summary>
        /// Price for the subscription
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(7,2)")]
        [Comment("Price of the subscription")]
        public decimal Price { get; set; }

        /// <summary>
        /// Is the subscription deleted
        /// </summary>
        [Required]
        [Comment("Is the subscription deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// List of users that are subscribed
        /// </summary>
        public List<UserSubscription> UsersSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
