using System;
using System.Collections.Generic;
using MailKit.Net.Smtp;
using MimeKit;


namespace EZCourse.Services
{
    public class Smtp
    {
        public void SendSingle(string subject, string htmlBody, string textBody,
            string toName, string toAddress, string fromName, string fromAddress)
        {
            /*  using (var client = new SmtpClient())
             {
                 client.Connect("mail.domain.com");
                 client.Authenticate("username", "password");
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
             } */
        }

    }
}
