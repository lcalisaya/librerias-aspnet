using MailKit.Intro.Models;
using MailKit.Intro.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MailKit.Intro.Controllers
{
    public class MailToController : Controller
    {
        private readonly IEmailSenderService _servicio;

        public MailToController(IEmailSenderService servicio)
        {
            _servicio = servicio;
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: MailToController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                MailTo datos = new MailTo();
                datos.MailReceiver = collection["MailReceiver"];
                datos.Subject = collection["Subject"];
                datos.Body = collection["Body"];

                await _servicio.SendEmailAsync(datos);

                TempData["UserMessage"] = $"Mail has been sent to {datos.MailReceiver}";
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

    }
}
