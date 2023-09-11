using Business.Abstarcts;
using Business.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Middleware;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiKeyAutFilter))]
        public IActionResult Get()
        {
            return Ok(_productService.GetAll());
        }
        [HttpGet("{productName}")]
        public IActionResult Get([FromRoute] string productName)
        {
            return Ok(_productService.GetAll(productName));
        }
        [HttpPost]
        public IActionResult Add(CreateProductRequest product)
        {
            _productService.Add(product);
            return Ok(product);
        }
        [HttpDelete]
        public IActionResult Delete(DeleteProductRequest product)
        {
            _productService.Delete(product);
            return Ok(product);
        }
        [HttpPut]
        public IActionResult Delete(UpdateProductRequest product)
        {
            _productService.Update(product);
            return Ok(product);
        }
    }
}
