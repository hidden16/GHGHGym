using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ApplicationUserConstant;

namespace GHGHGym.Infrastructure.Data.Models.Account
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        /// <summary>
        /// User's First Name
        /// </summary>
        [Required]
        [PersonalData]
        [MaxLength(FirstNameMaxLength)]
        [Comment("User's first name")]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// User's Last Name
        /// </summary>

        [Required]
        [PersonalData]
        [MaxLength(LastNameMaxLength)]
        [Comment("User's last name")]
        public string LastName { get; set; } = null!;
        /// <summary>
        /// User's Birth Date
        /// </summary>

        [Required]
        [Comment("User's birthdate")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// User's Registration Date
        /// </summary>

        [Required]
        [Comment("Account creation date")]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// User's Trainer Id
        /// </summary>

        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
        /// <summary>
        /// Is the User's account deleted or not
        /// </summary>

        [Required]
        [Comment("Is the account deleted")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// List of user's comments
        /// </summary>
        public List<Comment> Comments { get; set; } = new List<Comment>();

        /// <summary>
        /// List of user's purchased products
        /// </summary>
        public List<Product> PurchasedProducts { get; set; } = new List<Product>();

        /// <summary>
        /// List of user's images
        /// </summary>
        public List<UserImage> UsersImages { get; set; } = new List<UserImage>();

        /// <summary>
        /// List of user's subscriptions
        /// </summary>
        public List<UserSubscription> UsersSubscriptions { get; set; } = new List<UserSubscription>();
    }
}
