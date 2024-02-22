using Microsoft.AspNetCore.Mvc;
using UserDetails.Api.Models;
using UserDetails.Api.Services;

namespace UserDetails.Api.Controllers
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser([FromBody] UserDto user)
        {
            var userdetails = await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { userdetails.Id }, userdetails.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int userId, [FromBody] UserDto user)
        {
            if (userId != user.Id)
                return BadRequest();

            var result = await _userService.UpdateUser(user);

            if (result == 0)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUser(userId);

            if (result == 0)
                return NotFound();

            return NoContent();
        }
    }
}