using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        [Comment("Trainer add date")]
        public DateTime AddedOn { get; set; }
        [Comment("Trainer removal date")]
        public DateTime? RemovedOn { get; set; }
        [Required]
        [Comment("Is the entity deleted from the database")]
        public bool IsDeleted { get; set; } = false;
    }
}
