using System.ComponentModel.DataAnnotations;
using PaintSystemAPIVersionOne.Enum;

namespace PaintSystemAPIVersionOne.DTO;

public class PaintProductRequest
{   
    public decimal TotalPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    [Required] [MaxLength(50)] public string OrderReference { get; set; }
    [Required] public int UserId { get; set; }
    
}