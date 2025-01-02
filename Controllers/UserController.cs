using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/api/v1/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET /users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> ListAllUsersAsync()
        {
            return Ok((await _userService.ListAllUsersAsync()).Select(user => user.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user.AsDto());
        }
    }
}
