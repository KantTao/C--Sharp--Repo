using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintSystemAPIVersionOne.Model;

public class StockTransaction
{
    
    [Key]   
    public int Id { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    public int ReferenceOrderId { get; set; }
    public Order Order { get; set; }
    public DateTime CreatedAt { get; set; }
    
    
    
    [ForeignKey("PaintProduct")] public int PaintProductId { get; set; }
    public PaintProduct PaintProduct { get; set; }
    
    public ICollection<StockTransactionDetail> StockTransactionDetails { get; set; }
    
    public StockTransaction()
    {
    }
    
    
    
    public StockTransaction(int quantity, int referenceOrderId)
    {
        Quantity = quantity;
        ReferenceOrderId = referenceOrderId;
        CreatedAt = DateTime.Now;
    }
    
}