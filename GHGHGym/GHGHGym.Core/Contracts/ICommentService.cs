﻿using GHGHGym.Core.Models.Comments;

namespace GHGHGym.Core.Contracts
{
    public interface ICommentService
    {
        public void AddComment(string commentText, Guid userId, Guid productId);
        public IEnumerable<CommentViewModel> GetCommentByProductId(Guid productId);
        public IEnumerable<CommentViewModel> GetCommentByTrainerId(Guid trainerId);
        public Task<bool> CheckCommentUserBeforeEditAsync(Guid commentId, Guid userId);
        public Task DeleteCommentAsync(Guid commentId);

        public Task Edit(EditCommentViewModel model);
    }
}
