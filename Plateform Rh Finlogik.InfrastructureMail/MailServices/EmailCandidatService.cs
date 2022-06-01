

using Plateform_RH_Finlogik.Application.Contracts.Email;
using Plateform_RH_Finlogik.Application.Models.Email;
using System.Net;
using System.Net.Mail;

namespace Plateform_Rh_Finlogik.InfrastructureMail.MailServices
{
    public class EmailCandidatService : IMailCandidatService
    {
        public async Task SendEmailCandidatAsync(MailRequest mailRequest)
        {
            var email = new MailMessage();
            email.From = new MailAddress("islem.abid@enis.tn");
            email.To.Add(new MailAddress(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            email.Body = mailRequest.Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("islem.abid@enis.tn", "to07W_53Fu");
            smtp.EnableSsl = true;
            smtp.Send(email);
        }
    }
}
