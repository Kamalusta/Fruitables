using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController(ITestimonialService testimonialService) : ControllerBase
    {
        private readonly ITestimonialService _testimonialService = testimonialService;

        [HttpGet("getAllTestimonials")]
        public IActionResult GetAll()
        {
            var result = _testimonialService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addTestimonial")]
        public IActionResult Add(Testimonial testimonial)
        {
            var result = _testimonialService.Add(testimonial);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("deleteTestimonial")]
        public IActionResult Delete(int id)
        {
            var result = _testimonialService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateTestimonial")]
        public IActionResult Update(Testimonial testimonial)
        {
            var result = _testimonialService.Update(testimonial);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
