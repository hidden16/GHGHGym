using GHGHGym.Infrastructure.Data.Enumerations;
using GHGHGym.Infrastructure.Data.Models.Account;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Subscription
    {
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Type of the subscription")]
        public SubscriptionType SubscriptionType { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(7,2)")]
        [Comment("Price of the subscription")]
        public decimal Price { get; set; }

        [Required]
        public DateTime SubscriptionStartDate { get; set; }

        [Required]
        public DateTime SubscriptionEndDate { get; set; }

        public ICollection<ApplicationUser>? UsersSubscribed { get; set; }
    }
}
