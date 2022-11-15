using GHGHGym.Core.Services.EmailSender.Models;

namespace GHGHGym.Core.Services.EmailSender.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            IEnumerable<EmailAttachment> attachments = null);
    }
}
