using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpPost("addOrder")]
        public IActionResult Add(Order order)
        {
            var result =  _orderService.Add(order);
            if(result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("deleteOrder")]
        public IActionResult Delete(int id)
        {
            var result = _orderService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("updateOrder")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getOrders")]
        public IActionResult GetAllOrders() 
        {
            var result =_orderService.GetAllOrders();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
