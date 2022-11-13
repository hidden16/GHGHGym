using GHGHGym.Infrastructure.Abstractions.Models;
using GHGHGym.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;
namespace GHGHGym.Infrastructure.Data.Models
{
    public class Category : BaseDeletableModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public CategoryType CategoryType { get; set; }

        /// <summary>
        /// The main category will always be null. Shows the category with higher level of abstraction.
        /// </summary>
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public List<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}
