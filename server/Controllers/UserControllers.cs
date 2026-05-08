using GuitarWorld.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GuitarWorld.Dtos;

namespace GuitarWorld.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase {
    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserDto request) {
        try {
            bool isAlright = await _userService.AddUserAsync(request);

            if (isAlright) {
                return Ok(new { success = true });
            }

            return Conflict();
        } catch (Exception ex) {
            return StatusCode(500, "Error in server!");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Authorize([FromBody] UserDto request) {
        try {
            bool userExists = await _userService.UserExistsAsync(request);

            if (userExists) {
                return Ok(new { success = true });
            }

            return Conflict();
        } catch (Exception ex) {
            return StatusCode(500, "Error in server!");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] int userId) {
        try {
            var user = await _userService.GetUserAsync(userId);

            if (user != null) {
                return Ok(new { success = true, user });
            }

            return NotFound();
        } catch (Exception ex) {
            return StatusCode(500, "Error in server!");
        }
    }
}