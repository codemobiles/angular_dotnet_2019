using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mypos_api.Database;
using mypos_api.Models;
using mypos_api.repo;

namespace mypos_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {

        ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger, IProductRepo productRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
        }

        public IProductRepo _productRepo { get; }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            try
            {
                return Ok(_productRepo.GetProduct());
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute GET");
                return BadRequest();
            }
        }

        [HttpGet("{id}")] // localhost../product/{id}
        public IActionResult GetProduct(int id)
        {
            try
            {

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult NewProduct([FromForm] Products data)
        {
            try
            {

                return Created("", null);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct([FromForm] Products data, int id)
        {
            try
            {

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }









        [HttpGet("search")] // localhost.../product/search?name=xxxx&order=asc
        public IActionResult Search([FromQuery] string name, [FromQuery] string order)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}