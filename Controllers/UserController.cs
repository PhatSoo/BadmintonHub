using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Models;
using BadmintonHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST /register
        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterDto userDto)
        {
            var checkExistedUser = await _userService.GetUserByEmailAsync(userDto.Email);
            if (checkExistedUser is not null)
            {
                return BadRequest("Email has been used");
            }

            await _userService.RegisterAsync(userDto);
            return Created();
        }

        // POST /login
        [HttpPost("login")]
        public async Task<ActionResult> LoginAsync(LoginDto user)
        {
            var existingUser = await _userService.GetUserByEmailAsync(user.Email);
            if (existingUser is null)
            {
                return Unauthorized();
            }
            bool isPasswordCorrect = _userService.LoginAysnc(existingUser, user.Password);
            if (!isPasswordCorrect)
            {
                return Unauthorized();
            }
            return Ok(new { data = "12345" });
        }
    }
}
