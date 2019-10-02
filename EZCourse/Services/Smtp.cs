using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using MailKit.Security;

namespace EZCourse.Services
{
    public class Smtp
    {
        readonly SmtpOptions _smtpOptions;

        public Smtp(IOptions<SmtpOptions> smtpOptions)
        {
            _smtpOptions = smtpOptions.Value;
        }

        public void SendSingle(string subject, string htmlBody, string textBody,
            string toName, string toAddress, string fromName, string fromAddress)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_smtpOptions.SmtpAddress);
                //client.Connect("smtp.gmail.com", 587, SecureSocketOptions.SslOnConnect);
                client.Authenticate(_smtpOptions.SmtpUserName, _smtpOptions.SmtpPassword);
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls11;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlBody;
                bodyBuilder.TextBody = textBody;

                var message = new MimeMessage();
                message.Body = bodyBuilder.ToMessageBody();
                message.From.Add(new MailboxAddress(fromName, fromAddress));
                message.To.Add(new MailboxAddress(toName, toAddress));
                message.Subject = subject;
                client.Send(message);

                client.Disconnect(true);
            }
        }

    }
}
