using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Comments;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;

namespace GHGHGym.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        public CommentService(IRepository<Comment> commentRepository,
            IRepository<ApplicationUser> userRepository)
        {
            this.commentRepository = commentRepository;
            this.userRepository = userRepository;
        }
        public async Task AddComment(CommentViewModel model, Guid userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (model.ProductId != null)
            {
                await commentRepository.AddAsync(new Comment()
                {
                    Text = model.Text,
                    ProductId = model.ProductId,
                    ApplicationUserId = user.Id
                });
            }
            else
            {
                await commentRepository.AddAsync(new Comment()
                {
                    Text = model.Text,
                    TrainerId = model.TrainerId,
                    ApplicationUserId = user.Id
                });
            }
            await commentRepository.SaveChangesAsync();
        }
    }
}
