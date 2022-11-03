using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
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

            builder
                .Property(us => us.SubscriptionType)
                .IsRequired();
        }
    }
}
