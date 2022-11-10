using GHGHGym.Infrastructure.Abstractions.Contracts;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models.ImageMapping
{
    public class TrainerImage : IDeletableEntity
    {
        public Guid TrainerId { get; set; }
        [Required]
        public Trainer Trainer { get; set; } = null!;

        public Guid ImageId { get; set; }
        [Required]
        public Image Image { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
    }
}
