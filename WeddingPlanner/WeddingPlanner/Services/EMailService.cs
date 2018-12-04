using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

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

        private bool ValidMail( string mail_address )
        {

            Regex myRegex = new Regex( @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.IgnoreCase );
            return myRegex.IsMatch( mail_address );
        }

        public async Task<string> veri( string mail_address )
        {
            return ValidMail( mail_address ) ? "Adresse valide" : "Adresse invalide";
        }
    }
}

