//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using mvcgmail.Models;
//using System.Net;
//using System.Net.Mail;

//namespace LocHelp.Controllers.home
//{
//    public class MessagerieController : Controller
//    {
//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]

//        public ActionResult Index(LocHelp.Models.Messagerie messagerie)
//        {
//            MailMessage mailMessage = new MailMessage(messagerie.From, messagerie.To);
//            mailMessage.Subject = messagerie.Subject;
//            mailMessage.Body = messagerie.Body;
//            messagerie.IsBodyHtml = false;

//            SmtpClient smtp = new SmtpClient();
//            smtp.Host
//            return View();
//        }
//    }
//}
