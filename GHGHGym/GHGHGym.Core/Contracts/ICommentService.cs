using GHGHGym.Core.Models.Comments;

namespace GHGHGym.Core.Contracts
{
    public interface ICommentService
    {
        public Task AddComment(CommentViewModel model, Guid userId);
    }
}
