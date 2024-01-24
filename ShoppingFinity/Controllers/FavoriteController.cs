using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public FavoriteController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Get favorites
        [HttpGet("GetFavorites")]
        public async Task<IActionResult> GetFavorites()
        {
            var favorites = await _Repository.GetFavorite();

            if (favorites == null)
                NotFound();
            return Ok(favorites);
        }

        //Get favorite by user id
        [HttpGet("GetFavoritesByUser")]
        public async Task<IActionResult> GetFavoriteByUserId(string id)
        {
            var favorite = await _Repository.GetFavoriteById(id);

            if (favorite == null)
                NotFound();
            return Ok(favorite);
        }
    }
}
