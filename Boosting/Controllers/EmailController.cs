using Boosting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Boosting.Controllers
{
    public class EmailController : Controller
    {
        [HttpPost]
        public ActionResult Sent(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("ahrudan@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("kucashi69@gmail.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.name, model.emailAddress, model.message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "ahrudan@gmail.com",  // replace with valid value
                        Password = "1997Rasengan70"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    return RedirectToAction("SendSuccesfull");
                }
            }
            return View(model);
        }

        public ActionResult SendSuccesfull()
        {
            return View();
        }
    }
}