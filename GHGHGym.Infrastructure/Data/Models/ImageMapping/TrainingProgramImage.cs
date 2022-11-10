namespace GHGHGym.Infrastructure.Data.Models.ImageMapping
{
    public class TrainingProgramImage
    {
        public Guid TrainingProgramId { get; set; }
        public TrainingProgram TrainingProgram { get; set; } = null!;
        public Guid ImageId { get; set; }
        public Image Image { get; set; } = null!;
    }
}
