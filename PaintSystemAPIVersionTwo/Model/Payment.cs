using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintSystemAPIVersionOne.Model;

public class Payment
{   
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    
    public DateTime PaidAt { get; set; }

    [ForeignKey("Order")]
    [Required]
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    
    public Payment()
    {
    }

    public Payment(decimal amount)
    {
        Amount = amount;
        PaidAt = DateTime.Now;
    }
    
    
}