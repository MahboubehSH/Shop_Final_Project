using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace _0_Framework.Application.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("Arooj", "info@arooj.ir");
            message.From.Add(from);

            var to = new MailboxAddress("کاربر گرامی", destination);
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
                
            };

            message.Body = bodyBuilder.ToMessageBody();
            

            var client = new SmtpClient();
            client.Connect("185.226.134.152", 25,SecureSocketOptions.None);
            client.Authenticate("info@arooj.ir", "info_Email#password_1324");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}