
using System;
using System.Net;
using System.Net.Mail;
namespace LocHelp.Models
{
    public class Messagerie
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; internal set; }
        //public void SendMail()
        //{
        //    MailMessage mc = new MailMessage(System.Configuration.ConfigurationManager.AppSettings[“Email”].ToString(), To);
        //    mc.Subject = Subject;
        //    mc.Body = Body;
        //    mc.IsBodyHtml = false;
        //    SmtpClient smtp = new SmtpClient(“smtp.gmail.com”, 587);
        //    smtp.Timeout = 1000000;
        //    smtp.EnableSsl = true;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    NetworkCredential nc = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings[“Email”].ToString(), System.Configuration.ConfigurationManager.AppSettings[“Password”].ToString());
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = nc;
        //    smtp.Send(mc);
        //}
    }
}

