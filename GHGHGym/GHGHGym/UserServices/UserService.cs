using GHGHGym.Core.Models.User;
using GHGHGym.Core.Services.EmailSender.Contracts;
using GHGHGym.Infrastructure.Data.Common.Repositories.Contracts;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.UserServices.Contracts;
using Microsoft.AspNetCore.Identity;
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
        public UserService(IEmailSender emailSender,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> userRepository)
        {
            this.emailSender = emailSender;
            this.userManager = userManager;
            this.userRepository = userRepository;
        }
        public async Task SendEmailConfirmationAsync(ApplicationUser user, Task<string> token, string callbackUrl)
        {
            var code = token;
            var html = new StringBuilder();
            html.AppendLine($"<h1>Hello, mr. {user.LastName}</h1>");
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
                    TrainerId = user.TrainerId.ToString() ?? ""
                };
            }
            return null;
        }
    }
}
