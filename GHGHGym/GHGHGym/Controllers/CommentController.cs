﻿using GHGHGym.Core.Contracts;
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

        /// <summary>
        /// Adds comment in database
        /// </summary>
        /// <param name="productId">Id of the product for which the product is</param>
        /// <param name="commentText">The comment</param>
        /// <returns>Returns redirect to the method that gets all comments by id of the product</returns>
        [IgnoreAntiforgeryToken]
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

        [IgnoreAntiforgeryToken]
        public IActionResult GetAllCommentsByProductId(Guid productId)
        {
            var comments = commentService.GetCommentByProductId(productId);
            return PartialView(comments);
        }

        public async Task<IActionResult> Delete(Guid commentId, Guid productId)
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

        [HttpGet]
        public IActionResult EditProductComment(Guid commentId, Guid postId, string text)
        {
            var model = new EditCommentViewModel()
            {
                Text = text,
                CommentId = commentId,
                PostId = postId
            };
            return View(model);
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

        //for trainers GetAllCommentsByTrainerId(Guid trainerId)
    }
}
