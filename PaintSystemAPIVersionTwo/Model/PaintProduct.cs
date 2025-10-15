using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace PaintSystemAPIVersionOne.Model;

public class PaintProduct
{
    public int Id { get; set; }
    [Required, MaxLength(60)] public string Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerLitre { get; set; } //decimal 字面量 必须加上 m 或 M 后缀，否则会当作 double。

    [Required, MaxLength(15)] public string Color { get; set; }
    [Required, MaxLength(30)] public string GlossLevel { get; set; }
    [Required, MaxLength(20)] public string BaseType { get; set; }
    [Required, MaxLength(30)] public string Size { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    
    
    
    [ForeignKey("PaintBrand")] public int PaintBrandId { get; set; }
    public PaintBrand? PaintBrand  { get; set; }
    
    [ForeignKey("PaintSeries")] public int PaintSeriesId { get; set; }
    public PaintSeries? PaintSeries { get; set; }
    
    
    
    [ForeignKey("PaintCategories")] public int PaintCategoryId { get; set; }
    public PaintCategories? PaintCategories { get; set; }

    public PaintProductsStock?  PaintProductsStock { get; set; }
    
    public List<Order> Orders { get; set; } = new List<Order>();
    
    public List<OrderPaintProductDetail> OrderPaintProducts { get; set; } = new();
    public List<StockTransaction> StockTransactions { get; set; } = new();
 
    
    
    public PaintProduct()
    {
    }

    public PaintProduct(string name, decimal pricePerLitre, string color, string glossLevel, string baseType,
        string size, int stock)
    {
        Name = name;
        PricePerLitre = pricePerLitre;
        Color = color;
        GlossLevel = glossLevel;
        BaseType = baseType;
        Size = size;
        Stock = stock;
        CreatedAt = DateTime.Now;
    }
}