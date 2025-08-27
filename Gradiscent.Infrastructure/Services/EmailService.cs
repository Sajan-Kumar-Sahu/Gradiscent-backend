using Gradiscent.Application.Common.Settings;
using Gradiscent.Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Gradiscent.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using var smtp = new SmtpClient(_emailSettings.Smtp.Host, _emailSettings.Smtp.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.From, _emailSettings.Password),
                EnableSsl = true
            };

            var message = new MailMessage(_emailSettings.From, to, subject, body)
            {
                IsBodyHtml = true
            };

            await smtp.SendMailAsync(message);
        }

    }
}
