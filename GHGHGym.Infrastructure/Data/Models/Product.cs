using GHGHGym.Infrastructure.Data.Models.Account;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ProductConstant;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<ApplicationUser>? AppUsersPurchases { get; set; }
    }
}
