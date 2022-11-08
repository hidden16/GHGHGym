using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var parentCategoryOne = new Category()
            {
                Name = "Sports Supplements",
                CategoryType = CategoryType.MainCategory,
            };
            builder
                .HasData
                (
                    parentCategoryOne,
                    new Category()
                    {
                        Name = "Healthy Foods",
                        CategoryType = CategoryType.MainCategory
                    },
                    new Category()
                    {
                        Name = "Proteins",
                        ParentCategory = parentCategoryOne,
                        CategoryType = CategoryType.Category,
                    }

                );
        }
    }
}
