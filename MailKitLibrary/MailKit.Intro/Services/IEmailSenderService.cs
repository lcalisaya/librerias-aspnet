using MailKit.Intro.Models;
using System.Threading.Tasks;

namespace MailKit.Intro.Services
{
    public interface IEmailSenderService
    {
        //It receives mailTo object from the form
        Task SendEmailAsync(MailTo mailTo);
    }
}
