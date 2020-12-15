namespace LuxuryEstateProject.Services.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NullMessageSender : IEmailSender
    {
        /// <inheritdoc/>
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
