using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ProductConstant;
using static GHGHGym.Infrastructure.Constants.ErrorMessageConstants;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Models.Product
{
    // Think about a variant to add images. Maybe can use cloudinary or local save
    public class ProductViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameErrorMessage)]
        public string Name { get; set; } = null!;
        
        [Required]
        [Range(typeof(decimal), "1.00", "500.00", ConvertValueInInvariantCulture = true)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public List<CategoryProduct> ProductCategories { get; set; } = new List<CategoryProduct>();
    }
}
