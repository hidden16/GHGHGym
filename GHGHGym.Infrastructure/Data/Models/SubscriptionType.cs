using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.SubscriptionType;
namespace GHGHGym.Infrastructure.Data.Models
{
    public class SubscriptionType
    {
        /// <summary>
        /// Id ot the subscription type
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the subscription type
        /// </summary>
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Is the subscription type deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
