using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace WeddingPlanner.WebApp.Services
{
    public class EMailService
    {
      
        public async Task Mail( string mailadress, string object_mail, string mail )
        {
            var fromAddress = new MailAddress( "weddingorganizer123456@gmail.com", "WeddingOrganizer" );
            var toAddress = new MailAddress( mailadress );
            const string fromPassword = "wed123456";
            string subject = object_mail;
            string body = mail;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential( fromAddress.Address, fromPassword ),
                Timeout = 20000
            };
            using( var message = new MailMessage( fromAddress, toAddress )
            {
                Subject = subject,
                Body = body
            } )
            {
                await smtp.SendMailAsync( message );
            }
        }
    }
}

