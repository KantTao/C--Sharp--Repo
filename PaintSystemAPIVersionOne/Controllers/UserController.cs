using Microsoft.AspNetCore.Mvc;
using PaintSystemAPIVersionOne.Exceptions;
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
        
        var formatted = new FormattedResponse<List<User>>(
            response.Message,
            response.IsSuccess,
            response.IsSuccess ? 200 : 400,
            response.Data
        );
        
        if (!response.IsSuccess) return BadRequest(response.Message);

        return StatusCode(formatted.StatusCode, formatted);
    }
}