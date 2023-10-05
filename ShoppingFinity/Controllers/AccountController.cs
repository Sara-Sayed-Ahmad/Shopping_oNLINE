﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Model.Account;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthentication_Authorization _Autentication;

        public AccountController(IAuthentication_Authorization Authentication)
        {
            _Autentication = Authentication;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Registration(Registration dataRegister)
        {
            var user = await _Autentication.RegitrationUser(dataRegister);

            return Ok(user);
        }
    }
}