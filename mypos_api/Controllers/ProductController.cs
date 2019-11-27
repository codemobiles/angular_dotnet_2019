using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mypos_api.Database;
using mypos_api.repo;

namespace mypos_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
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
        public IActionResult Get()
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

        // [HttpPost]
        // public IActionResult Post([FromBody] modelType model)
        // {
        //     try
        //     {
        //         return Created("", null);
        //     }
        //     catch (Exception)
        //     {
        //         _logger.LogError("Failed to execute POST");
        //         return BadRequest();
        //     }
        // }

        // [HttpPut]
        // public IActionResult Put([FromBody] modelType model)
        // {
        //     try
        //     {
        //         return Ok();
        //     }
        //     catch (Exception)
        //     {
        //         _logger.LogError("Failed to execute PUT");
        //         return BadRequest();
        //     }
        // }

        // [HttpDelete]
        // public IActionResult Delete(inputType id)
        // {
        //     try
        //     {
        //         return Ok();
        //     }
        //     catch (Exception)
        //     {
        //         _logger.LogError("Failed to execute DELETE");
        //         return BadRequest();
        //     }
        // }
    }
}