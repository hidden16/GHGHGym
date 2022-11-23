using GHGHGym.Infrastructure.Abstractions.Models;
using GHGHGym.Infrastructure.Data.Models.Account;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.CommentConstant;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Comment : BaseDeletableModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        [Required]
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
