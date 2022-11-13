using GHGHGym.Core.Models.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GHGHGym.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid info.");
                return View();
            }

            return Ok();
        }
    }
}
