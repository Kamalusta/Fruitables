using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController(IShippingService shippingService) : ControllerBase
    {
        private readonly IShippingService _shippingService = shippingService;

        [HttpGet("getAllShipping")]
        public IActionResult GetAll()
        {
            var result = _shippingService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addShipping")]
        public IActionResult Add(Shipping shipping)
        {
            var result = _shippingService.Add(shipping);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("deleteShipping")]
        public IActionResult Delete(int id)
        {
            var result = _shippingService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateShipping")]
        public IActionResult Update(Shipping shipping)
        {
            var result = _shippingService.Update(shipping);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
