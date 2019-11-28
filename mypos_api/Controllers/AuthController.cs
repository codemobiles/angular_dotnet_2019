using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mypos_api.Models;
using mypos_api.repo;
using mypos_api.ViewModel;

namespace mypos_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, IAuthRepo authRepo, IMapper mapper)
        {
            _logger = logger;
            _authRepo = authRepo;
            _mapper = mapper;
        }

        private IAuthRepo _authRepo { get; }
        public IMapper _mapper { get; }

        [HttpPost("login")]
        public IActionResult Login(UsersViewModel usersViewModel)  // username, password
        {
            try
            {
                Users user = _mapper.Map<Users>(usersViewModel);

                (Users result, string token) = _authRepo.Login(user);
                if (result == null)
                {
                    return Unauthorized(new { token = String.Empty, message = "Username incorrect" });
                }
                if (String.IsNullOrEmpty(token))
                {
                    return Unauthorized(new { token = String.Empty, message = "Password incorrect" });
                }
                return Ok(new { token = token, message = "Login Successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login failure: {ex}");
                return StatusCode(500, new { token = String.Empty, message = ex });
            }
        }

        [HttpPost("[action]")]
        public IActionResult register(Users user)
        {
            try
            {
                _authRepo.Register(user);
                return Ok(new { result = "ok", message = "Register Successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Register failure: {ex}");
                return StatusCode(500, new { result = "nok", message = "Register Failure" });
            }
        }
    }
}