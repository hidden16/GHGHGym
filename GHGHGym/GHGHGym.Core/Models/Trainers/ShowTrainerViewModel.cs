namespace GHGHGym.Core.Models.Trainers
{
    public class ShowTrainerViewModel
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<string> ImageUrls { get; set; }
        public int TrainingProgramsCount { get; set; }
        public Guid? UserTrainerId { get; set; }
    }
}
