using GHGHGym.Infrastructure.Data.Models.Account;

namespace GHGHGym.UserServices.Contracts
{
    public interface IUserService
    {
        public Task SendEmailConfirmationAsync(ApplicationUser user, Task<string> token, string callbackUrl);
        public Task<string> ConfirmEmailAsync(ApplicationUser userId, string code);
    }
}
