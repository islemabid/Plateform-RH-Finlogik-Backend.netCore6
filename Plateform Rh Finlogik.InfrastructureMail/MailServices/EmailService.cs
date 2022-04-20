

using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Plateform_RH_Finlogik.Application.Contracts.EmailCandidat;
using Plateform_RH_Finlogik.Application.Models.EmailCandidat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Plateform_RH_Finlogik_.InfrastructureMail.MailServices
{     
           public class MailService : IMailService {
            
            public async Task SendEmailAsync(MailRequest mailRequest)
            {
                var email = new MailMessage();
                email.From = new MailAddress("islem.abid@enis.tn");
                email.To.Add(new MailAddress(mailRequest.ToEmail)); 
                email.Subject = mailRequest.Subject;
                email.Body= mailRequest.Body ;
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

