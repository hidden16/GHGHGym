using GHGHGym.Infrastructure.Abstractions.Contracts;
using GHGHGym.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ApplicationUserConstant;

namespace GHGHGym.Infrastructure.Data.Models.Account
{
    public class ApplicationUser : IdentityUser<Guid>, IDeletableEntity
    {
        [PersonalData]
        [MaxLength(FirstNameMaxLength)]
        public string? FirstName { get; set; } = null!;

        [PersonalData]
        [MaxLength(LastNameMaxLength)]
        public string? LastName { get; set; } = null!;

        public DateTime? BirthDate { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedOn { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        public Guid? ImageId { get; set; }
        public Image? Image { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<UserProduct> PurchasedProducts { get; set; } = new List<UserProduct>();

        public List<UserSubscription> UsersSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
