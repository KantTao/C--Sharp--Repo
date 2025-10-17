using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookManagementSystemAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BookManagementSystemAPI.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    
    
    public AuthService(UserManager<User> userManager,IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    
    
    public  async Task<string> Register(RegisterRequestDto registerRequest)
    {
        User user = new User
        {
            FullName = registerRequest.FullName,
            Email = registerRequest.Email,
            UserName =registerRequest.Email,
            LibraryReNo = Guid.NewGuid().ToString().Substring(0, 8) 
        };
        
        IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);

        if (result.Succeeded)
        {
            //Created JWT token
            string token = GenerateJwtToken(user);
            return token;
        }

// 打印出具体失败原因
        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
        throw new Exception($"Created User failed: {errors}");
        
        
    }
    
    private string GenerateJwtToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            
        };
        
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}