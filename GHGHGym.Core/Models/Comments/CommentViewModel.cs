using System.ComponentModel.DataAnnotations;
using static GHGHGym.Infrastructure.Constants.InfrastructureConstants.CommentConstant;
using static GHGHGym.Infrastructure.Constants.ErrorMessageConstants;
namespace GHGHGym.Core.Models.Comments
{
    public class CommentViewModel
    {
        [Required]
        [StringLength(TextMaxLength, MinimumLength = TextMinLength, ErrorMessage = NameErrorMessage)]
        public string Text { get; set; } = null!;
        public Guid? ProductId { get; set; }
        public Guid? TrainerId { get; set; }
    }   
}
