using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllUsersController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public AllUsersController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _Repository.GetAllUsers();
            
            if(users == null)
                NotFound();
            return Ok(users);

        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _Repository.GetUserById(id);

            if(user == null)
                NotFound();
            return Ok(user);
        }
    }
}