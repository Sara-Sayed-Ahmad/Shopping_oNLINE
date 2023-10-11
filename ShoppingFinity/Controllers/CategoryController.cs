using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public CategoryController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Get categories
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var category = await _Repository.GetCategories();

            if (category == null)
                NotFound();
            return Ok(category);
        }

        //Get category by Id
        [HttpGet("CategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _Repository.GetCategory(id);

            if (category == null)
                NotFound();
            return Ok(category);
        }
    }
}
