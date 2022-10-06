using GHGHGym.Infrastructure.Data.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Subscription
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Type of the subscription")]
        public SubscriptionType SubscriptionType { get; set; }

        [Required]
        [Comment("Price of the subscription")]
        public decimal Price { get; set; }
    }
}
