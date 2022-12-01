using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    internal class SeedSubscriptionTypeConfiguration : IEntityTypeConfiguration<SubscriptionType>
    {
        public void Configure(EntityTypeBuilder<SubscriptionType> builder)
        {
            builder
                .HasData
                (
                    new SubscriptionType()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Weekly"
                    }, 
                    new SubscriptionType()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Monthly"
                    },
                    new SubscriptionType()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Yearly"
                    },
                    new SubscriptionType()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Weekly with trainer"
                    },
                    new SubscriptionType()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Monthly with trainer"
                    },
                    new SubscriptionType()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Yearly with trainer"
                    }
                );
        }
    }
}
