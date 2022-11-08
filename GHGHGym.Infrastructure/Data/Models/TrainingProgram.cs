using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class TrainingProgram
    {
        /// <summary>
        /// Id of the training program
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the training program
        /// </summary>
        [Required]
        [Comment("Name of the program")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description of the program
        /// </summary>
        [Required]
        [Comment("Description of the training program")]
        public string ProgramDescription { get; set; } = null!;

        /// <summary>
        /// Id of the trainer that created the program
        /// </summary>
        [Required]
        public Guid TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;

        /// <summary>
        /// Is the program deleted
        /// </summary>
        [Comment("Is the entity deleted")]
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// Images of the training program
        /// </summary>
        public List<TrainingProgramImage> TrainingProgramImages { get; set; } = new List<TrainingProgramImage>();
    }
}
