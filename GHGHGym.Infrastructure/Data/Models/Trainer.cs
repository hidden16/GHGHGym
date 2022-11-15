using GHGHGym.Infrastructure.Abstractions.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.TrainerConstant;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Trainer : BaseDeletableModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? InstagramLink { get; set; }

        public string? FacebookLink { get; set; }

        public string? TwitterLink { get; set; }

        public Guid? ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser? ApplicationUser { get; set; }

        public List<TrainingProgram> TrainerPrograms { get; set; } = new List<TrainingProgram>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<ApplicationUser> UsersWithTrainer { get; set; } = new List<ApplicationUser>();

        public List<TrainerImage> TrainersImages { get; set; } = new List<TrainerImage>();
    }
}
