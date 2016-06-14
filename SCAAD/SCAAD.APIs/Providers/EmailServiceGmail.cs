using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using SCAAD.APIs.Models;
using static SCAAD.APIs.EmailTemplates.EmailHtmlTemplates;

namespace SCAAD.APIs.Providers
{

    public static class EmailServiceGmail
    {
        public static void  SendEmail(Usuario Usuario, EmailContent emailContent)
        {
            var fromAddress = new MailAddress("SCAADUABC@gmail.com", "SCAAD UABC");
            var toAddress = new MailAddress(Usuario.Email, Usuario.UserName);
            const string fromPassword = "SCAADUABC123456";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = emailContent.Subject,
                Body = emailContent.Body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
    }
}