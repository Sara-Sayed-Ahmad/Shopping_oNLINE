using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using ShoppingFinity.Model;
using ShoppingFinity.Model.Account;
using ShoppingFinity.Repository.Service;
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
        private readonly IConfiguration _config;
        private readonly ISendEmailService _sendEmail;

        public Authentication_Authorization(SystemDbContext context, UserManager<User> userManager
            , RoleManager<IdentityRole> roleManager, IConfiguration config, ISendEmailService sendEmail)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
            _sendEmail = sendEmail;
        }

        //Register User
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
                EmailConfirmed = false,
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

                //Token
                var Token = await _userManager.GenerateEmailConfirmationTokenAsync(RegisterUser);
                //var token = GenerateToken(RegisterUser);

                //Encoded
                var encodedEmailToken = Encoding.UTF8.GetBytes(Token);
                var validEmailToken = WebEncoders.Base64UrlEncode(encodedEmailToken);

                //url to confirm email
                string CallURL = $"https://localhost:7102/api/Account/ConfirmEmail?userid={RegisterUser.Id}&token={validEmailToken}";

                SendEmailData data = new SendEmailData()
                {
                    To = RegisterUser.Email,
                    Subject = "Confirm your email",
                    Body = $"<h1>Welcome to Shopping</h1>" + $"<p>Please confirm your email by <a href='{CallURL}'>Clicking here</a></p>"
                };

                await _sendEmail.SendEmail(data);
                // RegisterUser.AuthenticationToken = token;

                // Save the user with the confirmation token
                await _userManager.UpdateAsync(RegisterUser);
            }

            return result.Succeeded;
        }

        //Confirm Email
        public async Task<bool> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            //Decoded
            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            return result.Succeeded;
        }

        //Login user 
        public async Task<string> LoginUser(AuthenticateRequest authenticate)
        {
            var user = _context.User.SingleOrDefault(x => x.Email == authenticate.Email);

            var userRoles = await _userManager.GetRolesAsync(user);

            if (user == null || !await _userManager.CheckPasswordAsync(user, authenticate.Password))
            {
                throw new ApplicationException("Wrong email or password");
            }

            var authClaims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
            };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            //Generate Token
            var token = GenerateToken(authClaims);

            user.AuthenticationToken = token;

            return token;
        }

        private string GenerateToken(List<Claim> claim)
        {
            var JwtHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_config["JWTConfig:Secret"]);

            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = JwtHandler.CreateToken(TokenDescriptor);
            var jwtToken = JwtHandler.WriteToken(token);

            return jwtToken;
        }
    }
}