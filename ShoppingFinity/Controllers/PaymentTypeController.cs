using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingFinity.Repository;

namespace ShoppingFinity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly ShoppingIRepository _Repository;

        public PaymentTypeController(ShoppingIRepository repository)
        {
            _Repository = repository;
        }

        //Get payment Types
        [HttpGet("GetPaymentTypes")]
        public async Task<IActionResult> GetAllPaymentTypes()
        {
            var paymentTypes = await _Repository.GetAllPaymentType();

            if (paymentTypes == null)
                NotFound();
            return Ok(paymentTypes);
        }

        //Get Payment Type by id 
        [HttpGet("GetPaymentType")]
        public async Task<IActionResult> GetPaymentTypeById(int id)
        {
            var paymentType = await _Repository.GetPaymentTypeById(id);

            if (paymentType == null)
                NotFound();
            return Ok(paymentType);
        }
    }
}