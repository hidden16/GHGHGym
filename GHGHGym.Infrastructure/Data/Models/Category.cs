using GHGHGym.Infrastructure.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.Category;
namespace GHGHGym.Infrastructure.Data.Models
{
    /// <summary>
    /// Categories for the products
    /// </summary>
    public class Category
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

        [Required]
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        [Required]
        public bool IsDeleted { get; set; } = false;
        public List<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}
