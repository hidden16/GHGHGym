using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.CommentConstant;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Comment
    {
        [Comment("Primary key")]
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(TextMaxLength)]
        [Comment("Text of the comment")]
        public string Text { get; set; } = null!;

        [Required]
        [Comment("The date on which the comment was posted")]
        public DateTime PostedOn { get; set; }

        [Comment("The date on which the comment was deleted")]
        public DateTime? DeletedOn { get; set; }

        [Required]
        [Comment("Is the entity deleted from the database")]
        public bool IsDeleted { get; set; } = false;

        [Required]
        [Comment("Id of the trainer for whom the comment is written")]
        public Guid TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
    }
}
