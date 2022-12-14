using GHGHGym.Core.Contracts;
using GHGHGym.Core.Models.User;
using GHGHGym.Core.Services.EmailSender.Contracts;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.UserServices.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Encodings.Web;
using static Microsoft.AspNetCore.WebUtilities.WebEncoders;

namespace GHGHGym.UserServices
{
    // Cannot put the service in class library GHGHGym.Core because WebUtilities doesn't exist there.
    public class UserService : IUserService
    {
        private const string from = "ghghgym@abv.bg";
        private const string fromName = "Go Hard or Go Home Gym";
        private const string subject = "Email Confirmation";
        private IEmailSender emailSender;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly ITrainerService trainerService;
        public UserService(IEmailSender emailSender,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> userRepository,
            ITrainerService trainerService)
        {
            this.emailSender = emailSender;
            this.userManager = userManager;
            this.userRepository = userRepository;
            this.trainerService = trainerService;
        }
        public async Task DeleteAccount(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            userRepository.SetDeleted(user);
            user.FirstName = null;
            user.LastName = null;
            user.Email = null;
            user.NormalizedEmail = null;
            user.BirthDate = null;
            if (user.TrainerId != null)
            {
                await trainerService.QuitBeingTrainerAsync(userId.ToString());
            }
            user.TrainerId = null;
            user.UserName = null;
            user.NormalizedUserName = null;
            user.PhoneNumber = null;
            user.ImageId = null;

            userRepository.Update(user);
            await userRepository.SaveChangesAsync();
        }

        public async Task SendEmailConfirmationAsync(ApplicationUser user, Task<string> token, string callbackUrl)
        {
            var code = token;
            var html = new StringBuilder();
            html.AppendLine($"<h1>Hello, {user.LastName}</h1>");
            html.AppendLine($"<h3>To confirm your email click here => <a href=\"{HtmlEncoder.Default.Encode(callbackUrl)}\"> Confirm </a> <=</h3>");
            await emailSender.SendEmailAsync(from, fromName, user.Email, subject, html.ToString());
        }

        public async Task<string> ConfirmEmailAsync(ApplicationUser user, string code)
        {
            code = Encoding.UTF8.GetString(Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);
            var statusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            return statusMessage;
        }

        public async Task<UserViewModel> GetUserInformationAsync(Guid userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                return new UserViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailAddress = user.Email,
                    TrainerId = user.TrainerId ?? null
                };
            }
            return null;
        }

        public async Task<IEnumerable<UserViewModel>> AllUsersAsync()
        {
            return await userRepository.All()
                .Include(x=>x.UsersSubscriptions)
                .ThenInclude(x=>x.Subscription)
                .Select(x=> new UserViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    EmailAddress = x.Email,
                    RegistrationDate = x.RegistrationDate,
                    EmailConfirmed = x.EmailConfirmed,
                    TrainerId = x.TrainerId,
                    IsSubscribed = x.UsersSubscriptions.Any(x=>!x.IsDeleted)
                }).ToListAsync();
        }

        public async Task<IEnumerable<UserSubscriptionViewModel>> GetMySubscriptionsAsync(Guid userId)
        {
            var user = await userRepository.All()
                .Where(x => x.Id == userId)
                .Include(x => x.UsersSubscriptions)
                .ThenInclude(x => x.Subscription)
                .ThenInclude(x => x.SubscriptionType)
                .Include(x => x.UsersSubscriptions)
                .ThenInclude(x => x.Trainer)
                .FirstOrDefaultAsync();

            List<UserSubscriptionViewModel> userSub = new List<UserSubscriptionViewModel>();
            foreach (var item in user.UsersSubscriptions)
            {
                if (item.Trainer != null)
                {
                    userSub.Add(new UserSubscriptionViewModel()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        StartDate = item.SubscriptionStartDate.Date,
                        EndDate = item.SubscriptionEndDate.Date,
                        SubscriptionType = item.Subscription.SubscriptionType.Name,
                        TrainerFirstName = item.Trainer.FirstName,
                        TrainerLastName = item.Trainer.LastName,
                        SubscriptionId = item.SubscriptionId,
                        IsDeleted = item.IsDeleted
                    });
                }
                else
                {
                    userSub.Add(new UserSubscriptionViewModel()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        StartDate = item.SubscriptionStartDate.Date,
                        EndDate = item.SubscriptionEndDate.Date,
                        SubscriptionType = item.Subscription.SubscriptionType.Name,
                        SubscriptionId = item.SubscriptionId,
                        IsDeleted = item.IsDeleted
                    });
                }
            }
            return userSub;
        }
    }
}
