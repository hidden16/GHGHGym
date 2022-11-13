using GHGHGym.Infrastructure.Abstractions.Models;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.SubscriptionType;
namespace GHGHGym.Infrastructure.Data.Models
{
    public class SubscriptionType : BaseDeletableModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
