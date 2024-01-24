using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public TransactionController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Get transactions
        [HttpGet("GetTransaction")]
        public async Task<IActionResult> GetTransaction()
        {
            var transa = await _Repository.GetTransactions();

            if(transa == null)
                return NotFound();
            return Ok(transa);
        }

        //Get transaction by id
        [HttpGet("GetTransacById")]
        public async Task<IActionResult> GetTransactionByid(int id)
        {
            var transa = await _Repository.GetTransactionById(id);

            if (transa == null)
                return NotFound();
            return Ok(transa);
        }

        //Get transaction by user id
        [HttpGet("GetTransacByUser")]
        public async Task<IActionResult> GetTransactionByUser(string user)
        {
            var transa = await _Repository.GetTransactionByUser(user);

            if (transa == null)
                return NotFound();
            return Ok(transa);
        }

        //Get transaction by order id
        [HttpGet("GetTransacByOrder")]
        public async Task<IActionResult> GetTransactionByOrder(int id)
        {
            var transa = await _Repository.GetTransactionByOrder(id);

            if (transa == null)
                return NotFound();
            return Ok(transa);
        }
    }
}
