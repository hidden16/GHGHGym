using GHGHGym.UserServices.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GHGHGym.Areas.Admin.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
                this.userService = userService;
        }
        public async Task<IActionResult> All()
        {
            var model = await userService.AllUsersAsync();
            return View(model);
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            await userService.DeleteAccount(userId);
            return RedirectToAction(nameof(All));
        }
    }
}
