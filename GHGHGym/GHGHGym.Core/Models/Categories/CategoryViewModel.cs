using GHGHGym.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.ErrorMessageConstants;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;

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

        public IEnumerable<CategoryListViewModel> ParentCategories { get; set; } = new List<CategoryListViewModel>();
    }
}
