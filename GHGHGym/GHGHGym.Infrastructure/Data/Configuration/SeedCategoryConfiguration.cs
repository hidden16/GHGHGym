using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    internal class SeedCategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var parentCategory = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Sports Supplements",
                CategoryType = CategoryType.MainCategory,
            };
            builder
                .HasData
                (
                    parentCategory,
                    new Category()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Proteins",
                        ParentCategoryId = parentCategory.Id,
                        CategoryType = CategoryType.Category
                    }
                );
        }
    }
}
