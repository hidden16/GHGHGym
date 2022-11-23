using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration.ImagesConfiguration
{
    internal class TrainerImageConfiguration : IEntityTypeConfiguration<TrainerImage>
    {
        public void Configure(EntityTypeBuilder<TrainerImage> builder)
        {

            builder
                .HasKey(ti => new { ti.ImageId, ti.TrainerId });
        }
    }
}
