using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.TrainerConstant;

namespace GHGHGym.Core.Models.Trainers
{
    public class AddTrainerViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? InstagramLink { get; set; }

        public string? FacebookLink { get; set; }

        public string? TwitterLink { get; set; }

        public List<IFormFile>? Files { get; set; } = new List<IFormFile>();
        //filled in controller
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
