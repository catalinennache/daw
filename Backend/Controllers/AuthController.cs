using Microsoft.AspNetCore.Mvc;
using Chatty.Data;
using Chatty.Core;
using Chatty.Models.DTOs;
using Chatty.Models;
using Microsoft.AspNetCore.Authorization;


namespace Chatty.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    class AuthController : ControllerBase
    {
        AuthService authService;
        public AuthController(AuthService _authService)
        {
            authService = _authService;
        }
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserRequestDTO userDto)
        {
            var user = new User()
            {
                Email = userDto.Email,
                Password = userDto.Password

            };
            var response = authService.Authenticate(user);

            return Ok(response);

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(UserRequestDTO userDto)
        {
            var user = new User()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
            var token = authService.Register(user);
            return Ok(token);
        }
    }
}