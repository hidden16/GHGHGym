using GHGHGym.Core.Models.User;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.UserServices.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace GHGHGym.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private IUserService userService;
        public UserController(IUserService userService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.EmailAddress);

            if (user != null)
            {
                var userResult = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (userResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid info.");
                return View();
            }

            var emailCheck = await userManager.FindByEmailAsync(model.Email);

            if (emailCheck != null)
            {
                ModelState.AddModelError("", "User with that email already exists.");
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.GenderType,
                BirthDate = model.BirthDate,
                UserName = $"{model.FirstName}{model.LastName}",
            };

            var createResult = await userManager.CreateAsync(user, model.Password);
            if (createResult.Succeeded)
            {
                // UNCOMMENT CODE WHEN FINISHED WITH PROJECT
                // WORKING EMAIL SENDER WITH CONFIRMATION

                //var generatedToken = GenerateToken(user);
                //var callbackAction = Url.Action(
                //    action: "ConfirmEmail",
                //    controller: "User",
                //    values: new { userId = user.Id, code = generatedToken.Result },
                //    protocol: Request.Scheme
                //    );
                //await userService.SendEmailConfirmationAsync(user, generatedToken, callbackAction);

                //return RedirectToAction(nameof(PreConfirm));
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult PreConfirm()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            try
            {
                if (userId == null || code == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                var result = await userService.ConfirmEmailAsync(user, code);
                bool success = false;
                if (result.Contains("Thank"))
                {
                    success = true;
                }
                ViewBag.Result = result;
                ViewBag.Success = success;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            encodedToken = encodedToken.Replace(' ', '+');
            return encodedToken;
        }
    }
}
