using MailKit.Intro.Models;
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
        public Task SendEmailAsync(MailTo mailTo)
        {
            throw new NotImplementedException();
        }
    }
}
