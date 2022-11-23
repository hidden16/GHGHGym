using GHGHGym.Core.Services.EmailSender.Contracts;

namespace GHGHGym.Core.Services.EmailSender.Models
{
    public class NullMessageSender : IEmailSender
    {
        public Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            IEnumerable<EmailAttachment> attachments = null)
        {
            return Task.CompletedTask;
        }
    }
}
