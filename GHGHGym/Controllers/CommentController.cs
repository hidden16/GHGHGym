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
        [HttpGet]
        public IActionResult AddComment()
        {
            var model = new CommentViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComment(CommentViewModel model)
        {
            var userId = User?.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
            commentService.AddComment(model, Guid.Parse(userId));
            return View();
        }
    }
}
