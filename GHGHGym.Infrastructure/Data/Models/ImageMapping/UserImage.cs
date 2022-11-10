using GHGHGym.Infrastructure.Abstractions.Contracts;
using GHGHGym.Infrastructure.Data.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models.ImageMapping
{
    public class UserImage : IDeletableEntity 
    {
        public Guid UserId { get; set; }
        [Required]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid ImageId { get; set; }
        [Required]
        public Image Image { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
    }
}
