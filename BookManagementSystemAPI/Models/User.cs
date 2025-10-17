using Microsoft.AspNetCore.Identity;

namespace BookManagementSystemAPI.Models;

public class User: IdentityUser
{
    
    public string FullName { get; set; }
    public string LibraryReNo { get; set; }
    
}