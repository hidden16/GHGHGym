using GHGHGym.Infrastructure.Abstractions.Contracts;

namespace GHGHGym.Infrastructure.Data.Models.ImageMapping
{
    public class TrainingProgramImage : IDeletableEntity
    {
        public Guid TrainingProgramId { get; set; }
        public TrainingProgram TrainingProgram { get; set; } = null!;
        public Guid ImageId { get; set; }
        public Image Image { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
    }
}
