using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDetailsController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public CategoryDetailsController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Get details category
        [HttpGet("Details")]
        public async Task<IActionResult> GetDetails()
        {
            var detCategory = await _Repository.GetDetails();

            if (detCategory == null)
                NotFound();
            return Ok(detCategory);
        }

        //Get details category by Id
        [HttpGet("DetailsById")]
        public async Task<IActionResult> GetDetailsById(int id)
        {
            var DeCategory = await _Repository.GetDetailsById(id);

            if (DeCategory == null)
                NotFound();
            return Ok(DeCategory);
        }
    }
}
