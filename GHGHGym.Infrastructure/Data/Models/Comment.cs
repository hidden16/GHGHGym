using GHGHGym.Infrastructure.Data.Models.Account;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.CommentConstant;

namespace GHGHGym.Infrastructure.Data.Models
{
    public class Comment
    {
        /// <summary>
        /// Id of the comment
        /// </summary>
        [Comment("Primary key")]
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Text of the comment
        /// </summary>
        [Required]
        [MaxLength(TextMaxLength)]
        [Comment("Text of the comment")]
        public string Text { get; set; } = null!;
        /// <summary>
        /// The date on which the comment was posted
        /// </summary>

        [Required]
        [Comment("The date on which the comment was posted")]
        public DateTime PostedOn { get; set; }
        /// <summary>
        /// Is the entity deleted from the database
        /// </summary>

        [Required]
        [Comment("Is the entity deleted from the database")]
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// Id of the user who wrote the comment
        /// </summary>

        [Comment("Id of the user who wrote the comment")]
        public Guid? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        /// <summary>
        /// Id of the trainer for which the comment is related
        /// </summary>

        [Comment("Id of the trainer for which the comment is related")]
        public Guid? TrainerId { get; set; }
        public Trainer? Trainer { get; set; }
        /// <summary>
        /// Id of the product for which the comment is related
        /// </summary>

        [Comment("Id of the product for which the comment is related")]
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
