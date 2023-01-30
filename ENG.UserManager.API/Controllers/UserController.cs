using ENG.UserManager.Domain.Entities;
using ENG.UserManager.Domain.Interfaces.Services;
using ENG.UserManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ENG.UserManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // Get All users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        IEnumerable<User> users = await _userService.GetAllUsers();
        return Ok(users);
    }

    // Test Endpoint
    [HttpGet("test")]
    public bool TestEndpoint()
    {
        return true;
    }

    // Get All active users
    [HttpGet("active")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllActiveUsers()
    {
        IEnumerable<User> users = await _userService.GetAllActiveUsers();
        return Ok(users);
    }

    // Get user by id
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(string id)
    {
        if (!ObjectId.TryParse(id, out ObjectId objectId))
            return BadRequest("Invalid User Id format");
        User user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    // Create new user
    [HttpPost("create")]
    public async Task<ActionResult<User>> CreateUser([FromBody] UserCreateModel userCreateModel)
    {
        User user = await _userService.CreateUser(userCreateModel);
        return Ok(user);
    }

    // Update user data
    [HttpPut("update")]
    public async Task<IActionResult> UpdateUserData([FromBody] User usernewdata)
    {
        User user = await _userService.UpdateUserData(usernewdata);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    // Change Active state by id
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUserState(string id)
    {
        User user = await _userService.UpdateUserState(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    // Delete user by id
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var result = await _userService.DeleteUser(id);
        if (!result)
            return NotFound();
        return NoContent();
    }
}