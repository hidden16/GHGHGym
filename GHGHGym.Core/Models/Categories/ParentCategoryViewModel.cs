using GHGHGym.Infrastructure.Data.Models.Enums;

namespace GHGHGym.Core.Models.Categories
{
    public class ParentCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public CategoryType CategoryType { get; set; }

        public Guid? ParentCategoryId { get; set; }
    }
}
