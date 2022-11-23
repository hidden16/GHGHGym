using Ganss.Xss;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Comments;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models;
using GHGHGym.Infrastructure.Data.Models.Account;

namespace GHGHGym.Core.Services
{
    public class CommentService : ICommentService
    {
        private HtmlSanitizer sanitizer = new HtmlSanitizer();
        private readonly IRepository<Comment> commentRepository;
        private readonly IRepository<ApplicationUser> userRepository;
        public CommentService(IRepository<Comment> commentRepository,
            IRepository<ApplicationUser> userRepository)
        {
            this.commentRepository = commentRepository;
            this.userRepository = userRepository;
        }
        public void AddComment(string commentText, Guid userId, Guid productId)
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

        public  IEnumerable<CommentViewModel> GetCommentByProductId(Guid productId)
        {
            var product = commentRepository.All()
                .Where(x => x.ProductId == productId)
                .Select(x => new CommentViewModel()
                {
                    ProductId = x.ProductId,
                    Text = x.Text,
                    UserName = $"{x.ApplicationUser.FirstName} {x.ApplicationUser.LastName}",
                    CreatedOn = x.CreatedOn
                })
                .ToList();

            return product;
        }
    }
}
