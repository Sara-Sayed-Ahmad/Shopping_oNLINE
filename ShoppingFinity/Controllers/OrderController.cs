using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public OrderController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Get orders 
        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _Repository.GetOrders();

            if (orders == null)
                NotFound();
            return Ok(orders);
        }

        //Get order by id
        [HttpGet("GetOrderByid")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _Repository.GetOrderById(id);

            if (order == null)
                NotFound();
            return Ok(order);
        }

        //Get order by user id

        [HttpGet("GetOrderByUser")]
        public async Task<IActionResult> GetOrderByUser(string id)
        {
            var order = await _Repository.GetOrderByUser(id);

            if (order == null)
                NotFound();
            return Ok(order);
        }
    }
}
