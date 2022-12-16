namespace GHGHGym.Core.Models.User
{
    public class UserViewModel
    {
        public Guid? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public Guid? TrainerId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? IsSubscribed { get; set; }
    }
}
