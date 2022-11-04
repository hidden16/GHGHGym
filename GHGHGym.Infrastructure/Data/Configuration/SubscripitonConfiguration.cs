using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    internal class SubscripitonConfiguration : IEntityTypeConfiguration<Subscription>
    {
        private DbSet<SubscriptionType> subscriptionType;

        public SubscripitonConfiguration(DbSet<SubscriptionType> subscriptionType)
        {
                this.subscriptionType = subscriptionType;
        }
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            SubscriptionType[] subscriptionTypes = subscriptionType
                .OrderBy(st => st)
                .ToArray();
            builder
                .HasData(
                new Subscription()
                {
                    SubscriptionType = subscriptionTypes[0],
                    Price = 35.00m
                },
                new Subscription()
                {
                    SubscriptionType = subscriptionTypes[1],
                    Price = 120.00m
                },
                new Subscription()
                {
                    SubscriptionType = subscriptionTypes[2],
                    Price = 1300.00m
                },
                new Subscription()
                {
                    SubscriptionType= subscriptionTypes[3],
                    Price = 65.00m
                },
                new Subscription()
                {
                    SubscriptionType= subscriptionTypes[4],
                    Price = 160.00m
                },
                new Subscription()
                {
                    SubscriptionType = subscriptionTypes[5],
                    Price = 1700.00m
                }
                );
        }
    }
}
