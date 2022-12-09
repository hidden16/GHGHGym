using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static GHGHGym.Core.Constants.MessageConstant;

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

        /// <summary>
        /// Adds comment in database
        /// </summary>
        /// <param name="productId">Id of the product for which the product is</param>
        /// <param name="commentText">The comment</param>
        /// <returns>Returns redirect to the method that gets all comments by id of the product</returns>
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public IActionResult AddProductComment(Guid productId, string commentText)
        {
            var userId = User?.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                ModelState.AddModelError("", "Something went wrong");
                return this.RedirectToAction(nameof(GetAllCommentsByProductId), new { productId = productId });
            }
            commentService.AddProductComment(commentText, Guid.Parse(userId), productId);
            return this.RedirectToAction(nameof(GetAllCommentsByProductId), new { productId = productId });
        }
        [IgnoreAntiforgeryToken]
        [HttpPost]
        public IActionResult AddTrainerComment(Guid trainerId, string commentText)
        {
            var userId = User?.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                ModelState.AddModelError("", "Something went wrong");
                return this.RedirectToAction(nameof(GetAllCommentsByTrainerId), new { trainerId = trainerId });
            }
            commentService.AddTrainerComment(commentText, Guid.Parse(userId), trainerId);
            return this.RedirectToAction(nameof(GetAllCommentsByTrainerId), new { trainerId = trainerId });
        }

        [IgnoreAntiforgeryToken]
        public IActionResult GetAllCommentsByProductId(Guid productId)
        {
            var comments = commentService.GetCommentByProductId(productId);
            return PartialView(comments);
        }
        [IgnoreAntiforgeryToken]
        public IActionResult GetAllCommentsByTrainerId(Guid trainerId)
        {
            var comments = commentService.GetCommentByTrainerId(trainerId);
            return PartialView(comments);
        }

        public async Task<IActionResult> DeleteProduct(Guid commentId, Guid productId)
        {
            try
            {
                await commentService.DeleteCommentAsync(commentId);
                return RedirectToAction("ProductById", "Product", new { productId = productId });
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Product");
            }
        }
         public async Task<IActionResult> DeleteTrainer(Guid commentId, Guid trainerId)
        {
            try
            {
                await commentService.DeleteCommentAsync(commentId);
                return RedirectToAction("TrainerById", "Trainer", new { trainerId = trainerId });
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Trainer");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditTrainerComment(Guid commentId, Guid postId, string text, Guid userId)
        {
            if (await commentService.CheckCommentUserBeforeEditAsync(commentId, userId))
            {

                var model = new EditCommentViewModel()
                {
                    Text = text,
                    CommentId = commentId,
                    PostId = postId
                };
                return View(model);
            }
            TempData[ErrorMessage] = "You do not own this comment!";
            return RedirectToAction("All", "Trainer");
        }
        [HttpPost]
        public async Task<IActionResult> EditTrainerComment(EditCommentViewModel model)
        {
            try
            {
                await commentService.Edit(model);
                return RedirectToAction("TrainerById", "Trainer", new { trainerId = model.PostId });
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Trainer");
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditProductComment(Guid commentId, Guid postId, string text, Guid userId)
        {
            if (await commentService.CheckCommentUserBeforeEditAsync(commentId, userId))
            {

                var model = new EditCommentViewModel()
                {
                    Text = text,
                    CommentId = commentId,
                    PostId = postId
                };
                return View(model);
            }
            TempData[ErrorMessage] = "You do not own this comment!";
            return RedirectToAction("All", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> EditProductComment(EditCommentViewModel model)
        {
            try
            {
                await commentService.Edit(model);
                return RedirectToAction("ProductById", "Product", new { productId = model.PostId });
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Product");
            }
        }
    }
}
