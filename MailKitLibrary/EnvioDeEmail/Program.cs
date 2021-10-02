using System;
using System.Net.Mail;
using System.Net;

namespace SendingEmail
{
    public class Program
    {
        static void Main(string[] args)
        {

            string originEmail = "<username>@gmail.com";
            string destinationEmail = "<username>@gmail.com";
            string password = "<password>";

            MailMessage emailMessage = new MailMessage(originEmail, destinationEmail, "This is the subject", "<b>Message to Lucía Calisaya</b>");

            emailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            //smtpClient.Host = "smtp.gmail.com";
            //smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(originEmail, password);
           
            try
            {
                smtpClient.Send(emailMessage);
                smtpClient.Dispose();
                Console.WriteLine("Your email was sent!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
