using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ShoppingIRepository _Repository;

        public ProductController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Get all products
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProduct()
        {
            var products = await _Repository.GetProducts();

            if (products == null)
                NotFound();
            return Ok(products);
        }

        //Get product by id
        [HttpGet("GetProductbyId")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var prod = await _Repository.GetProductById(id);

            if (prod == null)
                NotFound();
            return Ok(prod);
        }
    }
}
