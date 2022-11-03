using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models.ImageMapping
{
    public class TrainerImage
    {
        public Guid TrainerId { get; set; }
        [Required]
        public Trainer Trainer { get; set; } = null!;

        public Guid ImageId { get; set; }
        [Required]
        public Image Image { get; set; } = null!;
    }
}
