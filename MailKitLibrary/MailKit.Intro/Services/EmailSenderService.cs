using MailKit.Intro.Models;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace MailKit.Intro.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailSenderService(SmtpSettings smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }
        public async Task SendEmailAsync(MailTo mailTo)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress("Lucía Calisaya", mailTo.MailReceiver));
                message.Subject = mailTo.Subject;
                message.Body = new TextPart("html") { Text = mailTo.Body };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_smtpSettings.Server);
                    await client.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
