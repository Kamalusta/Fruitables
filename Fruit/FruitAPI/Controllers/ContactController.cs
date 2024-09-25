using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IContactService contactService) : ControllerBase
    {
        private readonly IContactService _contactService = contactService;

        [HttpGet("getContact")]
        public IActionResult Get(int id)
        {
            var results = _contactService.Get(id);
            if (results.Success)
                return Ok(results);
            else return BadRequest(results);
        }

        [HttpPost("addContact")]
        public IActionResult Add(Contact contact)
        {
            var result = _contactService.Add(contact);
            if (result.Success) return Ok(result);
            else return BadRequest(result);
        }


        [HttpPut("deleteContact")]
        public IActionResult Delete(int id)
        {
            var result = _contactService.Delete(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("updateCotact")]
        public IActionResult Update(Contact contact)
        {
            var result = _contactService.Update(contact);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

    }
}
