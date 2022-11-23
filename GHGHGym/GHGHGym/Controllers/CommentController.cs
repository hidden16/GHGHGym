using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GHGHGym.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        public IActionResult AddComment(Guid productId, string commentText)
        {
            var userId = User?.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
            commentService.AddComment(commentText, Guid.Parse(userId), productId);
            return this.Redirect($"/Comment/GetAllCommentsByProductId?productId={productId}");
        }
        public IActionResult GetAllCommentsByProductId(Guid productId)
        {
            var comments = commentService.GetCommentByProductId(productId);
            return PartialView(comments);
        }

        //for trainers GetAllCommentsByTrainerId(Guid trainerId)
    }
}
