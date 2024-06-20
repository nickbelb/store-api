using BLL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [EnableCors("AllowLocalhost3000")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.GetAllProducts();
            if (products != null)
            {
                return Ok(products);
            }
            return BadRequest();
        }

        [HttpGet]
        [EnableCors("AllowLocalhost3000")]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await productService.GetProductById(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet]
        [EnableCors("AllowLocalhost3000")]
        [Route("category/{id}")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var product = await productService.GetProductByCategory(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
    }
}
