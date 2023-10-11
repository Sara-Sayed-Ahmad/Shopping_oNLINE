using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Model;
using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Repository;
using ShoppingFinity.Repository.Image;

namespace ShoppingFinity.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;
        private readonly IFileImages _images;

        public AdminController(ShoppingIRepository repository, IFileImages images)
        {
            _Repository = repository;
            _images = images;
        }

        //Authorized opertations for admin:

        //Add category
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDTO category)
        {
            await _Repository.AddCategories(category);

            return Ok("Category is Added");
        }

        //Add details for category by admin
        [HttpPost("AddDetailsCategory")]
        public  async Task<IActionResult> AddDetails([FromBody] AddDetailsDTO details)
        {
            await _Repository.AddDetailsCategory(details);

            return Ok("Details category is Added");
        }

        //Add Product 
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDTO prod)
        {
            await _Repository.AddProduct(prod);

            return Ok("Product added successfully");
        }

        [HttpPost("UpoladImage")]
        public async Task<IActionResult> Uploadimg([FromForm] AddImageDTO image)
        {
            var img = await _images.UploadImage(image);

            if(img == null)
                NotFound();
            return Ok(img);
        }

        //Add Size for product
        [HttpPost("AddSizeProduct")]
        public async Task<IActionResult> AddSize([FromBody] AddSizeDTO size)
        {
            await _Repository.AddSizeProduct(size);

            return Ok("Size added successfully");
        }
    }
}