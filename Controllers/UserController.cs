using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // ADMIN FUNCTIONS -- START
        // GET /users
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserDto>>> ListAllUsersAsync()
        {
            return Ok((await _userService.ListAllUsersAsync()).Select(user => user.AsDto()));
        }

        // GET /users/{id}
        [HttpGet("users/{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user.AsDto());
        }
        // ADMIN FUNCTIONS -- END

        // ALL USERS FUNCTIONS -- START
        // GET /profile
        [HttpGet("profile")]
        public async Task<ActionResult<UserDto>> GetProfile()
        {
            // get userId from token from header
            var userId = _userService.GetCurrentUserId();
            if (userId is null)
            {
                return Unauthorized();
            }

            // find user by userId
            var user = await _userService.GetUserByIdAsync(userId.Value);
            if (user is null)
            {
                return BadRequest();
            }
            return Ok(user.AsDto());
        }

        // PATCH /change-password
        [HttpPatch("change-password")]
        public async Task<ActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            // get userId from token from header
            var userId = _userService.GetCurrentUserId();
            if (userId is null)
            {
                return Unauthorized();
            }

            var result = await _userService.ChangePasswordAsync(userId, changePasswordDto.OldPassword, changePasswordDto.Password);

            if (result == Constants.PasswordChangeResult.UserNotFound)
            {
                return NotFound();
            }

            if (result == Constants.PasswordChangeResult.InvalidOldPassword)
            {
                return BadRequest("Invalid old password");
            }

            return NoContent();
        }
        // ALL USERS FUNCTIONS -- END
    }
}
