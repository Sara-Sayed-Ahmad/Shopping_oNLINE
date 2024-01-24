using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public ReviewController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Get Reviews
        [HttpGet("GetReviews")]
        public async Task<IActionResult> GetReviews()
        {
            var review = await _Repository.GetallReviews();

            if (review == null)
                return NotFound();
            return Ok(review);
        }

        //Get review by id

        [HttpGet("GetReviewById")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _Repository.GetReviewById(id);

            if (review == null)
                return NotFound();
            return Ok(review);
        }

        //Get review by product id 

        [HttpGet("GetReviewIdProduct")]
        public async Task<IActionResult> GetReviewByProduct(int id)
        {
            var review = await _Repository.GetReviewByIdPro(id);

            if (review == null)
                return NotFound();
            return Ok(review);
        }

        //Get review by user id

        [HttpGet("GetReviewIdUser")]
        public async Task<IActionResult> GetReviewByUser(string id)
        {
            var review = await _Repository.GetReviewByIdUser(id);

            if (review == null)
                return NotFound();
            return Ok(review);
        }
    }
}
