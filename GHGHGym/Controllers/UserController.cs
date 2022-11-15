using GHGHGym.Core.Models.UserViewModels;
using GHGHGym.Core.Services.EmailSender.Contracts;
using GHGHGym.Infrastructure.Data.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace GHGHGym.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private IEmailSender emailSender;

        public UserController(IEmailSender emailSender,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.emailSender = emailSender;
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
            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.GenderType,
                BirthDate = model.BirthDate,
                UserName = $"{model.FirstName}{model.LastName}"
            };

            var createResult = await userManager.CreateAsync(user, model.Password);
            if (createResult.Succeeded)
            {
                //await SendEmailConfirmation(model);
                return RedirectToAction(nameof(Login));
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // TODO: At the end make the confirmation token
        private async Task SendEmailConfirmation(RegisterViewModel model)
        {
            var html = new StringBuilder();
            html.AppendLine("<h1>Hello</h1>");
            html.AppendLine("<h3>This is test</h3>");
            //var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await emailSender.SendEmailAsync("ghghgym@abv.bg", "Go Hard or Go Home Gym", model.Email, "Email Confirmation", html.ToString());
        }
    }
}
