using BookManagementSystemAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookManagementSystemAPI.Services;

public interface IAuthService
{
   public   Task<string> Register(RegisterRequestDto registerRequest);
   
}