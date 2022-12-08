namespace GHGHGym.Core.Models.TrainingPrograms
{
    public class TrainingProgramViewModel
    {
        public Guid? TrainerId { get; set; }
        public Guid? TrainerUserId { get; set; }
        public Guid? ProgramId { get; set; }
        public string Name { get; set; } = null!;
        public string ProgramDescription { get; set; }
        public List<string> ImageUrls { get; set; }
        public bool IsDeleted { get; set; }
    }
}
