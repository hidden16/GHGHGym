using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration.ImagesConfiguration
{
    internal class TrainingProgramImageConfiguration : IEntityTypeConfiguration<TrainingProgramImage>
    {
        public void Configure(EntityTypeBuilder<TrainingProgramImage> builder)
        {
            builder
                .HasKey(x => new { x.ImageId, x.TrainingProgramId });
        }
    }
}
