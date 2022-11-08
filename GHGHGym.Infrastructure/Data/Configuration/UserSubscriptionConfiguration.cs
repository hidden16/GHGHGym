using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    internal class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
    {
        public void Configure(EntityTypeBuilder<UserSubscription> builder)
        {
            builder
                 .HasKey(us => new { us.SubscriptionId, us.UserId});

            builder
                .Property(us => us.SubscriptionStartDate)
                .IsRequired();

            builder
                .Property(us => us.SubscriptionEndDate)
                .IsRequired();
        }
    }
}
