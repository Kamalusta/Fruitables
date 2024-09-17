using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FruitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProduct")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetProduct(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAllProducts();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("GetProductsbyCategory")]
        public IActionResult GetProductsByCategory(int categoryId)
        {
            var result = _productService.GetProductsByCategory(categoryId);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPost("addProduct")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("deleteProduct")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("updateProduct")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

        [HttpGet("filterProductByName")]
        public IActionResult GetByName(string name)
        {
            var result = _productService.GetProductsByName(name);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result);
        }

    }
}
