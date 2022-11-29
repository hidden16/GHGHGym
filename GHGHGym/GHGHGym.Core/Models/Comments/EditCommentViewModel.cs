using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.CommentConstant;
using static GHGHGym.Infrastructure.Constants.ErrorMessageConstants;
namespace GHGHGym.Core.Models.Comments
{
    public class EditCommentViewModel
    {
        [Required]
        [StringLength(TextMaxLength, MinimumLength = TextMinLength, ErrorMessage = NameErrorMessage)]
        public string Text { get; set; } = null!;
        public Guid CommentId { get; set; }
        public Guid PostId { get; set; }
    }
}
