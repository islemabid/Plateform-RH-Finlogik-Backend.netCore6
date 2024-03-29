﻿

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
            email.IsBodyHtml = true;
            email.Body = @" <head>
<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
 <style type='text/css'>
 
   span.cls_002 {
     font-family: Arial, serif;
     font-size: 38.1px;
     color: rgb(0, 0, 0);
     font-weight: normal;
     font-style: normal;
     text-decoration: none
   }

 

   div.cls_002 {
     font-family: Arial, serif;
     font-size: 24.1px;
     color: rgb(0, 0, 0);
     font-weight: normal;
     font-style: normal;
     text-decoration: none
   }

   span.cls_003 {
     font-family: Arial, serif;
     font-size: 22.0px;
     
     color: rgb(0, 0, 0);
     font-weight: normal;
     font-style: normal;
     text-decoration: none
   }

   div.cls_003 {
     font-family: Arial, serif;
     font-size: 18.0px;
     color: rgb(0, 0, 0);
     font-weight: normal;
     font-style: normal;
     text-decoration: none
   }

   span.cls_004 {
     font-family: Arial, serif;
     font-size: 10.0px;
     color: rgb(0, 0, 0);
     font-weight: normal;
     font-style: normal;
     text-decoration: none
   }

   div.cls_004 {
     font-family: Arial, serif;
     font-size: 16.0px;
     color: rgb(0, 0, 0);
     font-weight: normal;
     font-style: normal;
     text-decoration: none
   }
 
   .bg_white
   {
   background:
   #ffffff;
   }
 
   table
   {
   border-spacing:
   0
    !important;
   border-collapse:
   collapse
    !important;
   table-layout:
   fixed
    !important;
   margin:
   5
   auto
    !important;
   }
   a
   {
   text-decoration:
   none;
   }
   h1,
   h2,
   h3,
   h4,
   h5,
   h6
   {
   font-family:
   'Poppins',
   sans-serif;
   color:
   #000000;
   margin-top:
   0;
   font-weight:
  750;
 
   }
   body
   {
   font-family:
   'Poppins',
   sans-serif;
   font-weight:
   500;
   font-size:
   15px;
   line-height:
   1.8;
   color:
   rgba(0,
   0,
   0,
   .4);
   }
   a
   {
   color:
   #FF8300;
   }
   .logo
   h1
   {
   margin:
   0;
   }
   .logo
   h1
   a
   {
   color:
   #FF8300;
   font-size:
   24px;
   font-weight:
   700;
   font-family:
   'Poppins',
   sans-serif;
   }
 
 
   
 </style>
 </head>
 <body width='90%' style='margin: 10; padding: 0 !important; mso-line-height-rule: exactly; background-color: #f1f1f1;'>
   <center style='width: 100%; background-color: #f1f1f1;'>
   
     <div style='max-width: 600px; margin: 0 auto;' class='email-container'>
       <table align='center' role='presentation' cellspacing='0' cellpadding='0'  width='70%' style='margin: auto;'>
         <tr>
           <td valign='top' class='bg_white' style='padding: 1em 2.5em 0 2.5em;text-align: center;'>
           <h1>
                     <p style='color:#c7db1e'>Finlogik Tunisie</p>
                   </h1>
                 </td>
               </tr>
           
        
               <tr>
                 <td class='bg_white' style='padding: 1em 2.5em 0 2.5em;text-align: center;'><div class='cls_002'>
                     
                   </div>
  <br>
                   <div class='cls_003'>
                     <span class='cls_003'>
" + mailRequest.Body + @"</span>
                   </div>              <br>
                   <br> Cordialement, <br> Equipe Finlogik <span>
  <br><br>
                  
 <br><br>
                 </td>
               </tr>
           
       </table>
 
     </div>
   </center>
 </body>
 </html>";
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
