namespace GHGHGym.Core.Models.TrainingPrograms
{
    public class TrainingProgramViewModel
    {
        public string Name { get; set; } = null!;
        public string ProgramDescription { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
