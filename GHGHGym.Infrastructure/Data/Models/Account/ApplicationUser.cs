using GHGHGym.Infrastructure.Abstractions.Contracts;
using GHGHGym.Infrastructure.Data.Models.Enums;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ApplicationUserConstant;

namespace GHGHGym.Infrastructure.Data.Models.Account
{
    public class ApplicationUser : IdentityUser<Guid>, IDeletableEntity
    {
        [Required]
        [PersonalData]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [PersonalData]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;


        [Required]
        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedOn { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Product> PurchasedProducts { get; set; } = new List<Product>();

        public List<UserImage> UsersImages { get; set; } = new List<UserImage>();

        public List<UserSubscription> UsersSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
