using MimeKit;

namespace ShoppingFinity.Repository
{
    public class EmailService
    {
        public async Task SendEmail(string email, string subject, string message)
        {
            //var emailMessage = new MimeMessage();
            //emailMessage.From.Add(new MailboxAddress("ShoppingFinity", "sarasayedahmad24@gmail.com"));
            //emailMessage.To.Add(new MailboxAddress("", email));
            //emailMessage.Subject = subject;

            //var bodyBuilder = new BodyBuilder();
        }
    }
}
