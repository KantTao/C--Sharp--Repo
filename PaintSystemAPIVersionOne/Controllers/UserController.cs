using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PaintSystemAPIVersionOne.Model;
using PaintSystemAPIVersionOne.Services;

namespace PaintSystemAPIVersionOne.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }
    
    
    
    /// <summary>
    /// Get all users to API 
    /// </summary>
    /// <returns>List of users </returns>
    [HttpGet("get-users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {   
        var response = await _userService.GetAllUsers();

        if (!response.IsSuccess) return BadRequest(response.Message);

        return response.Data;

    }
}