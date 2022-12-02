using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.TrainingPrograms;
using GHGHGym.Core.Services.CloudinaryService.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GHGHGym.Controllers
{
    [Authorize(Roles = "Trainer, Administrator")]
    public class TrainingProgramController : Controller
    {
        private readonly ITrainingProgramService trainingProgramService;
        private readonly ICloudinaryService cloudinaryService;
        public TrainingProgramController(ITrainingProgramService trainingProgramService,
            ICloudinaryService cloudinaryService)
        {
            this.trainingProgramService = trainingProgramService;
            this.cloudinaryService = cloudinaryService;
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
            return Ok();
        }
    }
}
