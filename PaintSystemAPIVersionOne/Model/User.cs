using System.ComponentModel.DataAnnotations;

namespace PaintSystemAPIVersionOne.Model;

public class User
{
    public int Id { get; set; }
    [Required, MaxLength(30)] public string PhoneNumber { get; set; }
    [Required, MaxLength(40)] public string Email { get; set; }
    [Required, MaxLength(40)] public string Address { get; set; }
    [Required, MaxLength(50)] public string DuluxAccountInfo { get; set; }
    public DateTime CreatedAt { get; set; }

    //User ---> order  (1 --> Many )
    public List<Order> Orders { get; set; } = new List<Order>();
    
    
    public User()
    {
    }
    
    public User(string phoneNumber, string email, string address, string duluxAccountInfo)
    {
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        DuluxAccountInfo = duluxAccountInfo;
        CreatedAt = DateTime.Now; // 或者 DateTime.UtcNow 更常用
    }
}