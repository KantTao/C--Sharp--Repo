using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintSystemAPIVersionOne.Model;

public class OrderPaintProductDetail
{
    
    [ForeignKey("Order")] 
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey("PaintProduct")]
    public int PaintProductId { get; set; }
    public PaintProduct PaintProduct { get; set; }
    
    
    
    // 可选的额外字段，比如购买数量、单价、小计金额等：
    [Required]
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public OrderPaintProductDetail() { }
    
    public OrderPaintProductDetail(int orderId, int paintProductId, int quantity, decimal unitPrice)
    {
        OrderId = orderId;
        PaintProductId = paintProductId;
        Quantity = quantity;
    }
    
    
    
}