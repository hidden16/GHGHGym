namespace GHGHGym.Core.Models.Trainers
{
    public class TrainerViewModel
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Description { get; set; }
        public string? InstagramLink { get; set; }
        public string? FacebookLink { get; set; }
        public string? TwitterLink { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
