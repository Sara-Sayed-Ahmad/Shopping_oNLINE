using Microsoft.AspNetCore.Identity;
using ShoppingFinity.Model.Account;

namespace ShoppingFinity.Repository
{
    public interface IAuthentication_Authorization
    {
        Task<bool> RegitrationUser(Registration user);
        Task<bool> ConfirmEmail(string userId, string token);
        Task<string> LoginUser(AuthenticateRequest authenticate);
    }
}
