using GHGHGym.Infrastructure.Abstractions.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Subscription : BaseDeletableModel
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
        /// List of users that are subscribed
        /// </summary>
        public List<UserSubscription> UsersSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
