using GHGHGym.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.ErrorMessageConstants;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ProductConstant;

namespace GHGHGym.Core.Models.Product
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

        public List<IFormFile> Files { get; set; } = new List<IFormFile>();

        public List<string> ImageUrls { get; set; } = new List<string>();
        public List<CategoryProduct> ProductCategories { get; set; } = new List<CategoryProduct>();
    }
}
