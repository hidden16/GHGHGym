using GHGHGym.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.ApplicationUserConstant;
using static GHGHGym.Infrastructure.Constants.ErrorMessageConstants;

namespace GHGHGym.Core.Models.UserViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [PersonalData]
        [Display(Name = "First name")]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = NameErrorMessage)]
        public string FirstName { get; set; } = null!;

        [Required]
        [PersonalData]
        [Display(Name = "Last name")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = NameErrorMessage)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public GenderType GenderType { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
