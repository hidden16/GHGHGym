using System.Security.Claims;
using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Trainers;
using GHGHGym.Core.Services.CloudinaryService.Contracts;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.UserServices.Contracts;
using static  GHGHGym.Core.Constants.MessageConstant;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GHGHGym.Areas.Admin.Controllers
{
    public class TrainerController : BaseController
    {
        private readonly ITrainerService trainerService;
        private readonly IUserService userService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly SignInManager<ApplicationUser> signManager;

        public TrainerController(ITrainerService trainerService,
            IUserService userService,
            ICloudinaryService cloudinaryService,
            SignInManager<ApplicationUser> signInManager)
        {
                this.trainerService = trainerService;
                this.userService = userService;
                this.cloudinaryService = cloudinaryService;
                this.signManager = signInManager;
        }
        public async Task<IActionResult> All()
        {
            var model = await trainerService.AllTrainersAsync(null);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await userService.GetUserInformationAsync(Guid.Parse(userId));
            if (user.TrainerId.ToString() == id.ToString() || User.IsInRole("Administrator"))
            {
                var model = await trainerService.GetForEditAsync(id);
                return View(model);
            }
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddTrainerViewModel model)
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
            await trainerService.EditAsync(model);
            return RedirectToAction(nameof(All));
        }
    }
}
