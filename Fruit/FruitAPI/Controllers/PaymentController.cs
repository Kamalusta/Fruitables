using Business.Abstract;
using Business.Helpers.Results.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {
        private readonly IPaymentService _paymentService = paymentService;

        [HttpGet("getAllPayments")]
        public IActionResult GetAll()
        {
            var result = _paymentService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addPayment")]
        public IActionResult Add(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("deletePayment")]
        public IActionResult Delete(int id) 
        {
            var result = _paymentService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updatePayment")]
        public IActionResult Update(Payment payment)
        {
            var result = _paymentService.Update(payment);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
