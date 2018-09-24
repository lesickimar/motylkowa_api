using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace mot_api.Configuration
{
    public class EmailSender
    {
        public void EmailSend(string body, string subject)
        {
            var fromAddress = new MailAddress("alert.email.api@gmail.com", "Test");
            var toAddress = new MailAddress("lesik92@gmail.com", "Odbieraj!");
            const string fromPassword = "piramida123";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
