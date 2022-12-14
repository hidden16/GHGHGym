using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Comments;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;

namespace GHGHGym.Core.Services
{
    public class CommentService : ICommentService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly IRepository<Comment> commentRepository;
        public CommentService(IRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public void AddProductComment(string commentText, Guid userId, Guid productId)
        {
            var comment = new Comment()
            {
                ApplicationUserId = userId,
                ProductId = productId,
                Text = sanitizer.Sanitize(commentText)
            };
            commentRepository.Add(comment);
            commentRepository.SaveChanges();
        }

        public IEnumerable<CommentViewModel> GetCommentByProductId(Guid productId)
        {
            var product = commentRepository.All()
                .Where(x => x.ProductId == productId)
                .Select(x => new CommentViewModel()
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    Text = x.Text,
                    UserName = $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}",
                    CreatedOn = x.CreatedOn,
                    UserId = x.ApplicationUserId.ToString()
                })
                .ToList();

            return product;
        }

        public async Task DeleteCommentAsync(Guid commentId)
        {
            await commentRepository.SetDeletedByIdAsync(commentId);
            await commentRepository.SaveChangesAsync();
        }

        public async Task Edit(EditCommentViewModel model)
        {
            var comment = await commentRepository.GetByIdAsync(model.CommentId);
            comment.Text = sanitizer.Sanitize(model.Text);
            comment.ModifiedOn = DateTime.UtcNow;
            commentRepository.Update(comment);
            await commentRepository.SaveChangesAsync();
        }

        public async Task<bool> CheckCommentUserBeforeEditAsync(Guid commentId, Guid userId)
        {
            var comment = await commentRepository.GetByIdAsync(commentId);
            if (comment.ApplicationUserId == userId)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<CommentViewModel> GetCommentByTrainerId(Guid trainerId)
        {
            var trainer = commentRepository.All()
                .Where(x => x.TrainerId == trainerId)
                .Select(x => new CommentViewModel()
                {
                    Id = x.Id,
                    TrainerId = x.TrainerId,
                    Text = x.Text,
                    UserName = $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}",
                    CreatedOn = x.CreatedOn,
                    UserId = x.ApplicationUserId.ToString()
                })
                .ToList();

            return trainer;
        }

        public void AddTrainerComment(string commentText, Guid userId, Guid trainerId)
        {
            var comment = new Comment()
            {
                ApplicationUserId = userId,
                TrainerId = trainerId,
                Text = sanitizer.Sanitize(commentText)
            };
            commentRepository.Add(comment);
            commentRepository.SaveChanges();
        }
    }
}
