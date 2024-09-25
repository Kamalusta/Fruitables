using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet("getCategories")]
        public IActionResult Get()
        {
            var result = _categoryService.GetAllCategories();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost("addCategory")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("deleteCategory")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("updateCategory")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

    }
}
