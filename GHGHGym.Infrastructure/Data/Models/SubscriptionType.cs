using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class SubscriptionType
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
