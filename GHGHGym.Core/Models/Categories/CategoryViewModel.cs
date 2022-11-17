using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Enums;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;
using static GHGHGym.Infrastructure.Constants.ErrorMessageConstants;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Core.Models.Categories
{
    public class CategoryViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameErrorMessage)]
        public string Name { get; set; } = null!;

        [Required]
        public CategoryType CategoryType { get; set; }

        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }

        public IEnumerable<Category> ParentCategories { get; set; } = new List<Category>();
    }
}
