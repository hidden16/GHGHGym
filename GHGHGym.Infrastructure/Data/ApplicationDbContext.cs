using GHGHGym.Infrastructure.Data.Configuration;
using GHGHGym.Infrastructure.Data.Configuration.ImagesConfiguration;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GHGHGym.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserSubscriptionConfiguration());
            builder.ApplyConfiguration(new SubscriptionTypeConfiguration());
            builder.ApplyConfiguration(new UserImageConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new TrainerImageConfiguration());
            builder.ApplyConfiguration(new TrainingProgramImageConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CategoryProductConfiguration());


            builder.Entity<TrainingProgram>()
                .HasOne(x => x.Trainer)
                .WithMany(x => x.TrainerPrograms)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
        public DbSet<ProductImage> ProductsImages { get; set; }
        public DbSet<TrainerImage> TrainersImages { get; set; }
        public DbSet<TrainingProgramImage> TrainingProgramImages { get; set; }
        public DbSet<UserImage> UsersImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoriesProducts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainingProgram> TrainerPrograms { get; set; }
        public DbSet<UserSubscription> UsersSubscriptions { get; set; }
    }
}