﻿using GHGHGym.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GHGHGym.Infrastructure.Data.Configuration
{
    public class SubscriptionTypeConfiguration : IEntityTypeConfiguration<SubscriptionType>
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
                    }
                );
        }
    }
}
