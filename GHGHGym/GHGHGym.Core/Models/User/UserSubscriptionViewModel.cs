namespace GHGHGym.Core.Models.User
{
    public class UserSubscriptionViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SubscriptionType { get; set; }
        public string? TrainerFirstName { get; set; }
        public string? TrainerLastName { get; set; }
        public Guid SubscriptionId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
