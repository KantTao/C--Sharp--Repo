using System.ComponentModel.DataAnnotations.Schema;

namespace PaintSystemAPIVersionOne.Model;

public class StockTransactionDetail
{
    
    [ForeignKey("PaintProductsStock")] 
    public int PaintProductsStockId { get; set; }
    public PaintProductsStock PaintProductsStock { get; set; }
    
    
    
    [ForeignKey("StockTransaction")] 
    public int StockTransactionId { get; set; }
    
    public StockTransaction StockTransaction { get; set; }
    
    // 可以加额外字段
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
    
    
}