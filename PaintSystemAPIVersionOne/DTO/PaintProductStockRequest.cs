using System.ComponentModel.DataAnnotations;
namespace PaintSystemAPIVersionOne.DTO;



public class PaintProductStockRequest
{   [Required]
    public int stockQuantity { get; set; }
    [Required]
    public int paintProductId { get; set; }
}