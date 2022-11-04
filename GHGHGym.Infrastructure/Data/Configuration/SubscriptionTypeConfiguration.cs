using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    internal class SubscriptionTypeConfiguration : IEntityTypeConfiguration<SubscriptionType>
    {
        public void Configure(EntityTypeBuilder<SubscriptionType> builder)
        {
            builder
                .HasData
                (
                    new SubscriptionType()
                    {
                        Name = "Weekly"
                    },new SubscriptionType()
                    {
                        Name = "Monthly"
                    },
                    new SubscriptionType()
                    {
                        Name = "Yearly"
                    },
                    new SubscriptionType()
                    {
                        Name = "Weekly with trainer"
                    },
                    new SubscriptionType()
                    {
                        Name = "Monthly with trainer"
                    },
                    new SubscriptionType()
                    {
                        Name = "Yearly with trainer"
                    }
                );
        }
    }
}
