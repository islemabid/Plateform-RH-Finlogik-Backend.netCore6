﻿
using System.Configuration;

using System.Net;
using System.Net.Mail;


namespace PLateform_RH_Finlogik.SendEmail.Helper
{
    public static class Mail
    {
        public static void sendMail(string to, string subject, string body)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(ConfigurationManager.AppSettings.Get("From"));
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = body;
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Port"));
            smtp.Host = ConfigurationManager.AppSettings.Get("Host");
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings.Get("From"), ConfigurationManager.AppSettings.Get("Passowrd"));
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);

        }


    }
}
