﻿using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Services.Interfaces;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
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
            if (userDto.Role.ToString() == "Staff" && userDto.PIN == null)
            {
                return BadRequest("PIN is required for Staff role!");
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
