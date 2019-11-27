using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mypos_api.Models;
using mypos_api.repo;

namespace mypos_api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, IAuthRepo authRepo)
        {
            _logger = logger;
            _authRepo = authRepo;
        }

        public IAuthRepo _authRepo { get; }

        [HttpPost("login")]
        public IActionResult Login(Users user)
        {
            try
            {
                (Users result, string token) = _authRepo.Login(user);
                if(result == null){
                    return Unauthorized(); // 401
                }

                if(String.IsNullOrEmpty(token)){
                    return Unauthorized(); //401
                }

                return Ok(token);
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
                _authRepo.Register(user);
                return Ok();
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute POST");
                return BadRequest();
            }
        }
    }
}