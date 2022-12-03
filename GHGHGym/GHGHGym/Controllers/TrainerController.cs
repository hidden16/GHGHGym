using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Trainers;
using GHGHGym.Core.Services.CloudinaryService.Contracts;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.UserServices.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static GHGHGym.Core.Constants.MessageConstant;

namespace GHGHGym.Controllers
{
    [Authorize]
    public class TrainerController : Controller
    {
        private readonly IUserService userService;
        private readonly ITrainerService trainerService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly SignInManager<ApplicationUser> signManager;
        public TrainerController(IUserService userService,
            ITrainerService trainerService,
            ICloudinaryService cloudinaryService,
            SignInManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.trainerService = trainerService;
            this.cloudinaryService = cloudinaryService;
            this.signManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            try
            {
                if (User.IsInRole("Trainer"))
                {
                    TempData[ErrorMessage] = "You are already a trainer!";
                    return RedirectToAction("Index", "Home");
                }
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var loadUserInfo = await userService.GetUserInformationAsync(Guid.Parse(userId));
                var model = new AddTrainerViewModel()
                {
                    FirstName = loadUserInfo.FirstName ?? "",
                    LastName = loadUserInfo.LastName ?? "",
                    EmailAddress = loadUserInfo.EmailAddress ?? ""
                };
                return View(model);
            }
            catch (Exception)
            {
                return View(new AddTrainerViewModel());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Become(AddTrainerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            List<string> imageUrls = new List<string>();
            foreach (var file in model.Files)
            {
                if (file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".jpeg"))
                {
                    var result = await cloudinaryService.UploadPhotoAsync(file, file.FileName.ToString());
                    imageUrls.Add(result);
                }
                else
                {
                    ModelState.AddModelError("Files", "Files are invalid");
                    return View(model);
                }
            }
            model.ImageUrls = imageUrls;
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            await trainerService.BecomeTrainerAsync(model, Guid.Parse(userId));
            TempData[SuccessMessage] = "You are now a Trainer!\r\nPlease RELOG to apply changes!";
            await signManager.SignOutAsync();
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public IActionResult All()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult TrainerById(Guid trainerId)
        {
            return Ok();
        }
    }
}
