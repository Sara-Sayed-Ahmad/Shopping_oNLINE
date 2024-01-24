using ShoppingFinity.Model.Account;

namespace ShoppingFinity.Repository.Service
{
    public interface ISendEmailService
    {
        //Send Email
        Task<bool> SendEmail(SendEmailData data);
    }
}
