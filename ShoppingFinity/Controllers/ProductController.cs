using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;
using ShoppingFinity.Repository.Image;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ShoppingIRepository _Repository;
        private IFileImages _images;

        public ProductController(ShoppingIRepository repository, IFileImages images)
        {
            _Repository = repository;
            _images = images;
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

        //Get products by detailsId
        [HttpGet("GetProductsByDetail")]
        public async Task<IActionResult> GetProductsDetail(int id)
        {
            var products = await _Repository.GetProductBydetails(id);

            if (products == null)
                NotFound();
            return Ok(products);
        }

        [HttpGet("GetImageById")]
        public async Task<IActionResult> GetImageById(int idProduct)
        {
            var image = await _images.GetImageById(idProduct);

            if (image == null)
                NotFound();
            return Ok(image);

        }
    }
}