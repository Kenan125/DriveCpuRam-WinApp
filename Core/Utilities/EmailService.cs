using System.Net;
using System.Net.Mail;

namespace Core.Utilities
{
    public class EmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("username", "password"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@example.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(to);

            smtpClient.Send(mailMessage);
        }
    }
}
