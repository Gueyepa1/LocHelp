<<<<<<< HEAD
﻿
using System;
using System.Net;
using System.Net.Mail;
=======
﻿using System;
>>>>>>> 8f7654d32d8ef8196010fd65e0b59cf46643052b
namespace LocHelp.Models
{
    public class Messagerie
    {
<<<<<<< HEAD
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
=======
        public string De { get; set; }
        public string A { get; set; }
        public string Objet { get; set; }
        public string Contenu { get; set; }
>>>>>>> 8f7654d32d8ef8196010fd65e0b59cf46643052b
    }
}

