using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products);
        }
    }
}
