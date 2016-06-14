using Autofac;
using SCAAD.APIs.App_Start;
using SCAAD.Contracts.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SCAAD.APIs.Providers
{
    public static class EmailService
    {
        private static int PORTNO = 25;

#if DEBUG
        private static string SMTPSERVER = "localhost";
#else
            private static string SMTPSERVER = "172.16.200.12";
#endif

        private static string EmailFromAdress = "intrasoft-dev@softtek.com";
        private static bool isBodyHtml = false;

        public static string SendEmail(string emailAddressTarget, string subject, string body)
        {
            string emailResult = string.Empty;
            try
            {
                MailMessage m = new MailMessage();
                m.From = new MailAddress(EmailFromAdress);
                m.To.Add(new MailAddress(emailAddressTarget));

                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = isBodyHtml;

                SmtpClient client = new SmtpClient(SMTPSERVER, PORTNO);
                client.Send(m);
                emailResult = "Email Send SuccessFully";
            }
            catch (Exception ex)
            {
                var e = ex;
            }

            return emailResult;
        }
    }
}