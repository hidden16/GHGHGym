using GHGHGym.Infrastructure.Abstractions.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ProductConstant;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Product : BaseDeletableModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public Guid? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; } = null!;

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<ApplicationUser> AppUsersPurchases { get; set; } = new List<ApplicationUser>();

        public List<ProductImage> ProductsImages { get; set; } = new List<ProductImage>();
    }
}
