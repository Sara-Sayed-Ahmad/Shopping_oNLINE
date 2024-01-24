using Microsoft.AspNetCore.Identity;
using ShoppingFinity.Model.Account;

namespace ShoppingFinity.Repository
{
    public interface IAuthentication_Authorization
    {
        //Register user
        Task<bool> RegitrationUser(Registration user);

        //Confirm Email 
        Task<bool> ConfirmEmail(string userId, string token);

        //Login User
        Task<string> LoginUser(AuthenticateRequest authenticate);
    }
}