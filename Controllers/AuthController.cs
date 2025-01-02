using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
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
            var token = _userService.LoginAysnc(existingUser, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token = token});
        }
    }
}
