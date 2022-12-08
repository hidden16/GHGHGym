using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.TrainingPrograms;
using GHGHGym.Core.Services.CloudinaryService.Contracts;
using GHGHGym.UserServices.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static GHGHGym.Core.Constants.MessageConstant;

namespace GHGHGym.Controllers
{
    [Authorize(Roles = "Trainer, Administrator")]
    public class TrainingProgramController : Controller
    {
        private readonly ITrainingProgramService trainingProgramService;
        private readonly ITrainerService trainerService;
        private readonly IUserService userService;
        private readonly ICloudinaryService cloudinaryService;
        public TrainingProgramController(ITrainingProgramService trainingProgramService,
            ITrainerService trainerService,
            IUserService userService,
            ICloudinaryService cloudinaryService)
        {
            this.trainingProgramService = trainingProgramService;
            this.trainerService = trainerService;
            this.userService = userService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllTrainerProgram(Guid trainerId, string trainerName)
        {
            ViewBag.TrainerName = trainerName;
            var model = await trainingProgramService.GetProgramsByTrainerIdAsync(trainerId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid programId)
        {
            try
            {
                var model = await trainingProgramService.GetProgramForEdit(programId);
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Trainer");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTrainingProgramViewModel model)
        {
            try
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
                await trainingProgramService.Edit(model);
                TempData[SuccessMessage] = "You succesfully Edited a training program!";
                return RedirectToAction("All", "Trainer");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occured!";
                return RedirectToAction("All", "Trainer");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateTrainingProgramViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTrainingProgramViewModel model)
        {
            try
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
                await trainingProgramService.AddProgramAsync(model, Guid.Parse(userId));
                TempData[SuccessMessage] = "You succesfully added a training program!";
                return RedirectToAction("All", "Trainer");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "You are not a trainer!";
                return RedirectToAction("All", "Trainer");
            }
        }
        public async Task<IActionResult> MyPrograms()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var user = await userService.GetUserInformationAsync(Guid.Parse(userId));
                if (user != null && user.TrainerId != null)
                {
                    var model = await trainingProgramService.GetProgramsByTrainerIdWithDeletedAsync(user.TrainerId ?? Guid.NewGuid());
                    if (model == null)
                    {
                        TempData[ErrorMessage] = "Error occured!";
                        return RedirectToAction("Index", "Home");
                    }
                    return View(model);
                }
                TempData[ErrorMessage] = "You are not a trainer!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occured!";
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> Delete(Guid programId)
        {
            try
            {
                await trainingProgramService.Delete(programId);
                TempData[SuccessMessage] = "Successfully deleted program!";
                return RedirectToAction(nameof(MyPrograms));
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Something went wrong!";
                return RedirectToAction("All", "Trainer");
            }
        }
        public async Task<IActionResult> Restore(Guid programId)
        {
            try
            {
                await trainingProgramService.Restore(programId);
                TempData[SuccessMessage] = "Successfully restored program!";
                return RedirectToAction(nameof(MyPrograms));
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Something went wrong!";
                return RedirectToAction("All", "Trainer");
            }
        }
    }
}
