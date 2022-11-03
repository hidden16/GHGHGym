using GHGHGym.Infrastructure.Data.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHGHGym.Infrastructure.Data.Models.ImageMapping
{
    public class UserImage
    {
        public Guid UserId { get; set; }
        [Required]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid ImageId { get; set; }
        [Required]
        public Image Image { get; set; } = null!;
    }
}
