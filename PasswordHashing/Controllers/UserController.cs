using Microsoft.AspNetCore.Mvc;
using PasswordHashing.Dtos;
using PasswordHashing.Services;
using System.ComponentModel.DataAnnotations;

namespace PasswordHashing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(";", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new ValidationException($"{errors}");
            }
            _userService.Register(userDto);
            return Ok("User have register successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(";", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                throw new ValidationException($"{errors}");
            }
            _userService.Login(loginDto);
            return Ok("Login successful");
        }
    }
}