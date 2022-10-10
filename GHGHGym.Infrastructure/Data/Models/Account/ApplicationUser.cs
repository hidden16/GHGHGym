using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ApplicationUserConstant;

namespace GHGHGym.Infrastructure.Data.Models.Account
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        [PersonalData]
        [MaxLength(FirstNameMaxLength)]
        [MinLength(FirstNameMinLength)]
        [Comment("User's first name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [PersonalData]
        [MaxLength(LastNameMaxLength)]
        [MinLength(LastNameMinLength)]
        [Comment("User's last name")]
        public string LastName { get; set; } = null!;

        [Required]
        [Comment("User's birthdate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Comment("Account creation date")]
        public DateTime RegistrationDate { get; set; }

        public Guid? SubscriptionId { get; set; }
        public Subscription? Subscription { get; set; }

        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        [Required]
        [Comment("Is the account deleted")]
        public bool IsDeleted { get; set; } = false;
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Product>? PurchasedProducts { get; set; }
    }
}
