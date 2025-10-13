using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PaintSystemAPIVersionOne.Enum;
namespace PaintSystemAPIVersionOne.Model;



public class Order
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    [Required] public OrderStatus OrderStatus { get; set; }
    [Required] [MaxLength(50)] public string OrderReference { get; set; }
    public DateTime CreatedAt { get; set; }
    
    [ForeignKey("User")] public int UserId { get; set; }

    public StockTransaction? StockTransaction { get; set; }
    
    //多对多的中间表导航属性添加
    public List<OrderPaintProductDetail>? OrderPaintProducts { get; set; } = new();
    public User? User { get; set; }
    public Payment? Payment { get; set; }
    
    
    
    public Order()
    {
    }
    
    
    public Order(decimal totalPrice, OrderStatus orderStatus, string orderReference)
    {
        TotalPrice = totalPrice;
        OrderStatus = orderStatus;
        OrderReference = orderReference;
        CreatedAt = DateTime.Now;
    }
}