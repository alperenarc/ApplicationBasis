using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationBasis
{
    public class EmailHelper
    {
        public static void SendMail(string FromMail, string ToMail, string Message,
            string Subject, string ServerConnect, string AuthPassword)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(FromMail));
            message.To.Add(new MailboxAddress(ToMail));
            message.Subject = Subject;
            message.Body = new TextPart("html")
            {
                Text = Message
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(ServerConnect, 587, false);
                client.Authenticate(FromMail, AuthPassword);
                client.Send(message);
                client.Disconnect(true);
            };
        }
    }
}
