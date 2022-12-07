using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Subscriptions;
using GHGHGym.Core.MultiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static GHGHGym.Core.Constants.MessageConstant;

namespace GHGHGym.Controllers
{
    [Authorize]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            this.subscriptionService = subscriptionService;
        }
        [HttpGet]
        public async Task<IActionResult> SubscribeToTrainer(Guid trainerId, string trainerName)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (await subscriptionService.IsUserSubscribedAsync(Guid.Parse(userId)))
            {
                TempData[ErrorMessage] = "You are already subscribed";
                return RedirectToAction("All", "Trainer");
            }
            if (User.IsInRole("Administrator") || User.IsInRole("Trainer"))
            {
                TempData[ErrorMessage] = "Administrators and trainers can't subscribe!";
                return RedirectToAction("All", "Trainer");
            }
            var model = new SubscriptionMultiModel()
            {
                SubscriptionDto = new SubscriptionViewModel()
                {
                    TrainerId = trainerId,
                    TrainerName = trainerName
                },
                SubscriptionTypesDto = subscriptionService.AllWithTrainerSubscriptionTypes()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SubscribeToTrainer(SubscriptionMultiModel model)
        {
            try
            {
                model.SubscriptionTypesDto = subscriptionService.AllWithTrainerSubscriptionTypes();
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(SubscribeToTrainer), new { trainerId = model.SubscriptionDto.TrainerId, trainerName = model.SubscriptionDto.TrainerName });
                }

                if (model.SubscriptionDto.StartDate.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError("", "Invalid date");
                    TempData[ErrorMessage] = "The date you entered is invalid!";
                    return RedirectToAction(nameof(SubscribeToTrainer), new { trainerId = model.SubscriptionDto.TrainerId, trainerName = model.SubscriptionDto.TrainerName });
                }
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                await subscriptionService.SubscribeAsync(model.SubscriptionDto, Guid.Parse(userId));
                TempData[SuccessMessage] = "Thank you for your subscription!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("All", "Trainer");
            }
        }
    }
}
