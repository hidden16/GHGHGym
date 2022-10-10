using GHGHGym.Infrastructure.Data.Models.Account;
using System.ComponentModel.DataAnnotations;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }

        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        public Guid? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
