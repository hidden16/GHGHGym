namespace GHGHGym.Core.Models.TrainingPrograms
{
    public class TrainingProgramViewModel
    {
        public Guid TrainerId { get; set; }
        public Guid? TrainerIdToCompare { get; set; }
        public string Name { get; set; } = null!;
        public string ProgramDescription { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
