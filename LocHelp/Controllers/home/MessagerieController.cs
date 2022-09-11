using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocHelp.Controllers.home
{
    public class MessagerieController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LocHelp.Models.Messagerie model)
        {

            MailMessage mail = new MailMessage("lochelpisika@gmail.com", model.De);
            mail.Subject = model.Objet;
            mail.Body = model.Contenu;
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("lochelpisika@gmail.com", "limqzsfrkcxugnpi");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mail);
            ViewBag.Message = "Le mail est envoyé avec succès !";
            return View();
        }
    }
}

