namespace PaintSystemAPIVersionOne.DTO;
using System.ComponentModel.DataAnnotations;

public class OrderCreateRequest
{
    [Required] public decimal TotalPrice { get; set; }
    [Required] public int OrderStatus { get; set; }
    [Required] [MaxLength(50)] public string OrderReference { get; set; } = string.Empty;
    [Required] public int UserId { get; set; }
}