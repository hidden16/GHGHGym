using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.TrainerConstant;

namespace GHGHGym.Infrastructure.Data.Models
{
    [Comment("Trainers in the gym")]
    public class Trainer
    {
        /// <summary>
        /// Id of the trainer
        /// </summary>
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }

        /// <summary>
        /// First name of the trainer
        /// </summary>
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("First name of the trainer")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Last name of the trainer
        /// </summary>
        [MaxLength(LastNameMaxLength)]
        [Comment("Last name of the trainer")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Phone number of the trainer
        /// </summary>
        [Required]
        [Comment("Phone number of the trainer")]
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Email address of the trainer
        /// </summary>
        [Required]
        [EmailAddress]
        [Comment("Email address of the trainer")]
        public string EmailAddress { get; set; } = null!;

        /// <summary>
        /// Description of the trainer
        /// </summary>
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Trainer description")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Instagram link of the trainer
        /// </summary>
        [Comment("Link for Instagram profile")]
        public string? InstagramLink { get; set; }

        /// <summary>
        /// Facebook link of the trainer
        /// </summary>
        [Comment("Link for Facebook profile")]
        public string? FacebookLink { get; set; }

        /// <summary>
        /// Twitter link of the trainer
        /// </summary>
        [Comment("Link for Twitter profile")]
        public string? TwitterLink { get; set; }

        /// <summary>
        /// The date on which the trainer was added
        /// </summary>
        [Required]
        [Comment("Trainer add date")]
        public DateTime AddedOn { get; set; }

        /// <summary>
        /// The date on which the trainer was removed
        /// </summary>
        [Comment("Trainer removal date")]
        public DateTime? RemovedOn { get; set; }

        /// <summary>
        /// Is the trainer deleted
        /// </summary>
        [Required]
        [Comment("Is the entity deleted from the database")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// List of the trainer programs
        /// </summary>

        [Comment("Collection of trainer programs")]
        public List<TrainingProgram> TrainerProgram { get; set; } = new List<TrainingProgram>();

        [Comment("Collection of comments for the trainer")]
        public List<Comment> Comments { get; set; } = new List<Comment>();

        [Comment("Users that are subscribed with trainer")]
        public List<ApplicationUser> UsersWithTrainer { get; set; } = new List<ApplicationUser>();

        [Comment("Images of the trainer")]
        public List<TrainerImage> TrainersImages { get; set; } = new List<TrainerImage>();
    }
}
