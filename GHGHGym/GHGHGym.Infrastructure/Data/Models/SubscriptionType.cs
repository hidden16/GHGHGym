using GHGHGym.Infrastructure.Abstractions.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
    }
}
