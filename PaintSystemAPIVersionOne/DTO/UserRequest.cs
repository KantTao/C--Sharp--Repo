using System.ComponentModel.DataAnnotations;

namespace PaintSystemAPIVersionOne.DTO;

public class UserRequest
{
     [Required]
     [Phone]
     public string PhoneNumber { get; set; }
     
     [Required]
     [EmailAddress]
     public string Email { get; set; }
     public string Address { get; set; }
     public string DuluxAccountInfo { get; set; }
}

