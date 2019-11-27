using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mypos_api.Models;

namespace mypos_api.Controllers
{

    [ApiController]
    [Route("[controller]")]    // localhost..../product
    public class AuthController : ControllerBase
    {

        ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }


        [HttpPost("login")]
        public IActionResult Login(Users user)
        {
            try
            {
                return Created("", null);
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute POST");
                return BadRequest();
            }
        }

        [HttpPost("[action_name]")]
        public IActionResult register(Users user)
        {
            try
            {
                return Created("", null);
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute POST");
                return BadRequest();
            }
        }
    }
}