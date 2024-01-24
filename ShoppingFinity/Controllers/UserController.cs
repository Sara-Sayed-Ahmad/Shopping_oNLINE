using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Model.AddDTOs;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    //[Authorize(Roles ="User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public UserController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Add product in favorite 
        [HttpPost("AddFavorite")]
        public async Task<IActionResult> AddFavorite(AddFavoriteDTO favo)
        {
            await _Repository.AddFavorite(favo);

            return Ok("Product Saved");
        }

        //Add order
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrder order)
        {
            await _Repository.AddOrder(order);

            return Ok("Order added");
        }

        //Add Review
        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview(AddReviewDTO review)
        {
            await _Repository.AddReview(review);

            return Ok("Review added");
        }
    }
}