using GHGHGym.Infrastructure.Abstractions.Models;
using GHGHGym.Infrastructure.Data.Models.ImageMapping;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Image : BaseDeletableModel
    {
        /// <summary>
        /// Id of the image
        /// </summary>
        [Key]
        [Comment("Id of the image")]
        public Guid Id { get; set; }

        /// <summary>
        /// URL of the image as a string
        /// </summary>
        [Required]
        [Comment("URL of the image as a string")]
        public string ImageUrl { get; set; } = null!;

        /// <summary>
        /// List of images of the users
        /// </summary>
        public List<UserImage> UsersImages { get; set; } = new List<UserImage>();

        /// <summary>
        /// List of images of the products
        /// </summary>
        public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        /// <summary>
        /// List of images of the trainers
        /// </summary>
        public List<TrainerImage> TrainersImages { get; set; } = new List<TrainerImage>();

        /// <summary>
        /// List of images of the training programmes
        /// </summary>
        public List<TrainingProgramImage> TrainingProgramImages { get; set; } = new List<TrainingProgramImage>();
    }
}
