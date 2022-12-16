using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.Subscriptions;
using GHGHGym.Core.MultiModels;
using GHGHGym.UserServices.Contracts;
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
        private readonly IUserService userService;
        public SubscriptionController(ISubscriptionService subscriptionService,
            IUserService userService)
        {
            this.subscriptionService = subscriptionService;
            this.userService = userService;
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

        [HttpGet]
        public async Task<IActionResult> Subscribe()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (await subscriptionService.IsUserSubscribedAsync(Guid.Parse(userId)))
            {
                TempData[ErrorMessage] = "You are already subscribed";
                return RedirectToAction("Index", "Home");
            }
            if (User.IsInRole("Administrator") || User.IsInRole("Trainer"))
            {
                TempData[ErrorMessage] = "Administrators and trainers can't subscribe!";
                return RedirectToAction("Index", "Home");
            }
            var model = new SubscriptionMultiModel()
            {
                SubscriptionDto = new SubscriptionViewModel(),
                SubscriptionTypesDto = subscriptionService.AllWithoutTrainerSubscriptionTypes()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscriptionMultiModel model)
        {
            try
            {
                model.SubscriptionTypesDto = subscriptionService.AllWithoutTrainerSubscriptionTypes();
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (model.SubscriptionDto.StartDate.Date < DateTime.Now.Date)
                {
                    ModelState.AddModelError("", "Invalid date");
                    TempData[ErrorMessage] = "The date you entered is invalid!";
                    return RedirectToAction("Index", "Home");
                }
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                await subscriptionService.SubscribeAsync(model.SubscriptionDto, Guid.Parse(userId));
                TempData[SuccessMessage] = "Thank you for your subscription!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> MySubscriptions()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var model = await userService.GetMySubscriptionsAsync(Guid.Parse(userId));
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Unsubscribe(Guid subscriptionId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                await subscriptionService.UnsubscribeAsync(subscriptionId, userId);
                TempData[SuccessMessage] = "Successfully unsubscribed!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Something went wrong!";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
