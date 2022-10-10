﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class TrainingProgram
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Comment("Name of the program")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Description of the training program")]
        public string ProgramDescription { get; set; } = null!;

        public ICollection<string>? ImagesUrl { get; set; }

        [Required]
        public Guid TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;

        [Comment("Is the entity deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
