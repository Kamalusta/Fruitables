using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentController(IUserCommentService userCommentService) : ControllerBase
    {
        private readonly IUserCommentService _userCommentService = userCommentService;

        [HttpGet("getAllUserComments")]
        public IActionResult GetAll()
        {
            var result = _userCommentService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("addUserComment")]
        public IActionResult Add(UserComment userComment)
        {
            var result = _userCommentService.Add(userComment);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("deleteUserComment")]
        public IActionResult Delete(int id)
        {
            var result = _userCommentService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("updateUserComment")]
        public IActionResult Update(UserComment userComment)
        {
            var result = _userCommentService.Update(userComment);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
