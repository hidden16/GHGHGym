using GHGHGym.Core.Services.EmailSender.Contracts;
using GHGHGym.Infrastructure.Data.Models.Account;
using GHGHGym.UserServices.Contracts;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Text.Encodings.Web;
using static Microsoft.AspNetCore.WebUtilities.WebEncoders;

namespace GHGHGym.UserServices
{
    // TODO: Put the service in .core class library services
    public class UserService : IUserService
    {
        private IEmailSender emailSender;
        private readonly UserManager<ApplicationUser> userManager;

        public object WebEncoders { get; private set; }

        public UserService(IEmailSender emailSender,
            UserManager<ApplicationUser> userManager)
        {
            this.emailSender = emailSender;
            this.userManager = userManager;
        }
        public async Task SendEmailConfirmationAsync(ApplicationUser user, Task<string> token, string callbackUrl)
        {
            var code = token;
            var html = new StringBuilder();
            html.AppendLine("<h1>Hello</h1>");
            html.AppendLine("<h3>This is test</h3>");
            html.AppendLine($"<a href=\"{HtmlEncoder.Default.Encode(callbackUrl)}\"> Confirm </a>");
            await emailSender.SendEmailAsync("ghghgym@abv.bg", "Go Hard or Go Home Gym", user.Email, "Email Confirmation", html.ToString());

        }

        public async Task<string> ConfirmEmailAsync(ApplicationUser user, string code)
        {
            code = Encoding.UTF8.GetString(Base64UrlDecode(code));
            var result = await userManager.ConfirmEmailAsync(user, code);
            var statusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            return statusMessage;
        }
    }
}
