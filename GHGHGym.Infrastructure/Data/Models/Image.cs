using GHGHGym.Infrastructure.Abstractions.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Image : BaseDeletableModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public List<ApplicationUser> UsersImages { get; set; } = new List<ApplicationUser>();

        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        public List<TrainerImage> TrainersImages { get; set; } = new List<TrainerImage>();

        public List<TrainingProgramImage> TrainingProgramImages { get; set; } = new List<TrainingProgramImage>();
    }
}
