using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Core.Models.UserViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
