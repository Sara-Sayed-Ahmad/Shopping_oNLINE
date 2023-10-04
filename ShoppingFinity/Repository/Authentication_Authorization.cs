using Microsoft.AspNetCore.Identity;
using ShoppingFinity.Model;
using ShoppingFinity.Model.Account;

namespace ShoppingFinity.Repository
{
    public class Authentication_Authorization: IAuthentication_Authorization
    {
        private readonly SystemDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Authentication_Authorization(SystemDbContext context, UserManager<User> userManager
            , RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> RegitrationUser(Registration user)
        {
           var userReg = await _userManager.FindByEmailAsync(user.Email);

            //if user already create account on the same email entered
            if (userReg != null)
            {
                throw new ApplicationException("Email '" + user.Email + "' is already taken");
            }

            if(user.Password != user.verifyPassword)
            {
                throw new ApplicationException("Password is incorrect");
            }

            var RigsterUser = new User()
            {
                UserName = user.FirstName + " " + user.LastName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(RigsterUser, user.Password);

            //Generate token 
            if (result.Succeeded)
            {

            }

            return true;
        }
    }
}