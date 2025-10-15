using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PaintSystemAPIVersionOne.Model;

public class PaintProductsStock
{   
    
    public int Id { get; set; }
    [Required] public int StockQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    
    [ForeignKey("PaintProduct")] public int PaintProductId { get; set; }
    public PaintProduct? PaintProduct { get; set; }
    
    public ICollection<StockTransactionDetail>? StockTransactionDetails { get; set; }
    
    
    
    public PaintProductsStock()
    {
    }
    
    public PaintProductsStock(int stockQuantity)
    {
        StockQuantity = stockQuantity;
        CreatedAt = DateTime.Now;
    }
}