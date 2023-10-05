using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using ShoppingFinity.Configration;
using ShoppingFinity.Model;
using ShoppingFinity.Model.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace ShoppingFinity.Repository
{
    public class Authentication_Authorization: IAuthentication_Authorization
    {
        private readonly SystemDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTConfig _configJWT;
        private readonly IConfiguration _config;

        public Authentication_Authorization(SystemDbContext context, UserManager<User> userManager
            , RoleManager<IdentityRole> roleManager, JWTConfig configJWT, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configJWT = configJWT;
            _config = config;
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

            var RegisterUser = new User()
            {
                UserName = user.FirstName + user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                AuthenticationToken = "null"
            };

            var result = await _userManager.CreateAsync(RegisterUser, user.Password);
            
            if (result.Succeeded)
            {
                if (user.IsAdmin)
                {
                    if (!await _roleManager.RoleExistsAsync(Roles.Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole()
                        {
                            Name = Roles.Admin
                        });
                    }
                    await _userManager.AddToRoleAsync(RegisterUser, Roles.Admin);
                    RegisterUser.IsAdmin = true;
                }
                else
                {
                    if (!await _roleManager.RoleExistsAsync(Roles.User))
                    {
                        await _roleManager.CreateAsync(new IdentityRole()
                        {
                            Name = Roles.User
                        });
                    }
                    await _userManager.AddToRoleAsync(RegisterUser, Roles.User);
                    RegisterUser.IsAdmin = false;
                }

                //var Token = await _userManager.GenerateEmailConfirmationTokenAsync(RegisterUser);
                var token = GenerateToken(RegisterUser);

                RegisterUser.AuthenticationToken = token;

                // Save the user with the confirmation token
                await _userManager.UpdateAsync(RegisterUser);
            }

            return result.Succeeded;
        }

        public string GenerateToken(IdentityUser user)
        {
            var JwtHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_config["JWTConfig:Secret"]);

            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
                }),

                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = JwtHandler.CreateToken(TokenDescriptor);
            var jwtToken = JwtHandler.WriteToken(token);

            return jwtToken;
        }
    }
}