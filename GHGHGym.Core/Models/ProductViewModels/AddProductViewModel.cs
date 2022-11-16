using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ProductConstant;
using static GHGHGym.Infrastructure.Constants.ErrorMessageConstants;

namespace GHGHGym.Core.Models.ProductViewModels
{
    // Think about a variant to add images. Maybe can use cloudinary or local save
    public class AddProductViewModel
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
    }
}
