using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Model;
using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public AdminController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryDTO category)
        {
            await _Repository.AddCategories(category);

            return Ok("Category is Added");
        }

        [HttpPost("AddDetailsCategory")]
        public async Task<IActionResult> AddDetails(AddDetailsDTO details)
        {
            await _Repository.AddDetailsCategory(details);

            return Ok("Details category is Added");
        }
    }
}