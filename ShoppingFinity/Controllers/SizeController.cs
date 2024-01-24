using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public SizeController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet("GetSizeById")]
        public async Task<IActionResult> GetSizeById(int ids)
        {
            var size = await _Repository.GetSizeByIds(ids);

            if (size == null)
                return BadRequest("Not found");
            return Ok(size);
        }

        [HttpGet("GetSizeByIdProd")]
        public async Task<IActionResult> GetSizeByIdProd(int idp)
        {
            var size = await _Repository.GetSizeByIdPro(idp);

            if (size == null)
                return BadRequest("Not Found");
            return Ok(size);
        }
    }
}
