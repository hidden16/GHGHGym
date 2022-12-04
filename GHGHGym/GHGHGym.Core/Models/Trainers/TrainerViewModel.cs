namespace GHGHGym.Core.Models.Trainers
{
    public class TrainerViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string> ImageUrls { get; set; }

    }
}
