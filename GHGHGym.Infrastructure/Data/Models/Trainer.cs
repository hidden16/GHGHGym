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
        [Key]
        [Comment("Primary key")]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("First name of the trainer")]
        public string FirstName { get; set; } = null!;

        [MaxLength(LastNameMaxLength)]
        [Comment("Last name of the trainer")]
        public string LastName { get; set; } = null!;

        [Required]
        [Comment("Phone number of the trainer")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Comment("Email address of the trainer")]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Trainer description")]
        public string Description { get; set; } = null!;

        [Comment("Link for Instagram profile")]
        public string? InstagramLink { get; set; }
        [Comment("Link for Facebook profile")]
        public string? FacebookLink { get; set; }
        [Comment("Link for Twitter profile")]
        public string? TwitterLink { get; set; }

        [Required]
        [Comment("Trainer add date")]
        public DateTime AddedOn { get; set; }

        [Comment("Trainer removal date")]
        public DateTime? RemovedOn { get; set; }

        [Required]
        [Comment("Is the entity deleted from the database")]
        public bool IsDeleted { get; set; } = false;

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
