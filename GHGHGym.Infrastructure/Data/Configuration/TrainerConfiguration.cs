using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    internal class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {

            builder
                .HasOne(x => x.ApplicationUser)
                .WithOne(x => x.Trainer);
        }
    }
}
