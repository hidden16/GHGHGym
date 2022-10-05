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
        [MaxLength(25)]
        [Comment("First name of the trainer")]
        public string FirstName { get; set; } = null!;

        [MaxLength(25)]
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

        [Required]
        [Comment("Trainer add date")]
        public DateTime AddedOn { get; set; }

        [Comment("Trainer removal date")]
        public DateTime? RemovedOn { get; set; }

        [Required]
        [Comment("Is the entity deleted from the database")]
        public bool IsDeleted { get; set; } = false;

        // add comment
    }
}
