using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace ResidentPortal.Models
{
    public class MessageModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        public MessageModel()
        {                        
        }
        
        public void SendMessage()
        {
            MailAddress fromAddress = new MailAddress("cmmonroe2010@gmail.com", "Colin Monroe");
            MailAddress toAddress = new MailAddress("colin.m.monroe@gmail.com", "Monsiuer Monroe");
            const string fromPwd = "msuspartans";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPwd)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = Subject,
                Body = Body
            })
            {
                smtp.Send(message);
            }
        }
    }
}