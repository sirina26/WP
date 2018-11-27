using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;
using System.Net.Mail;
using System.Net;
using System.Web;



namespace WeddingPlanner.DAL
{
    public class EMailGateway
    {
        readonly string _connectionString;

        public EMailGateway( string connectionString )
        {
            _connectionString = connectionString;
        }

        public async Task<Result<int>> Mail( string object_mail, string mail, string mailadress )
        {

            MailMessage msg = new MailMessage();
            msg.To.Add( mailadress );
            msg.From = new MailAddress(mailadress);
            msg.Subject = object_mail;
            msg.Body = mail;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "replay-hosting-secureserver.net";
            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential( "sirinesassi1996@gmail.com", ".." );

            return Result.Success( 0 );

        }
        public async Task SendEmail( string toEmailAddress, string emailSubject, string emailMessage )
        {
            var message = new MailMessage();
            message.To.Add( toEmailAddress );

            message.Subject = emailSubject;
            message.Body = emailMessage;

            using( var smtpClient = new SmtpClient() )
            {
                await smtpClient.SendMailAsync( message );
            }
        }

    }
}
