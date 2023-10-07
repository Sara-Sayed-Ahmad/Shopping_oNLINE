using ShoppingFinity.Model.Account;

namespace ShoppingFinity.Repository.Service
{
    public interface ISendEmailService
    {
        Task<bool> SendEmail(SendEmailData data);
    }
}
