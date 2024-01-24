using ShoppingFinity.Model.Account;
using System.Net;
using System.Net.Mail;

namespace ShoppingFinity.Repository.Service
{
    public class SendEmailService :ISendEmailService
    {
        public async Task<bool> SendEmail(SendEmailData data)
        {
            MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress("shania52@ethereal.email");
            emailMessage.To.Add(data.To);
            emailMessage.Subject = data.Subject;
            emailMessage.Body = data.Body;
            emailMessage.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.ethereal.email";

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("shania52@ethereal.email", "8gjxVMEq9JY7yyTShT");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(emailMessage);

            return true;
        }
    }
}
