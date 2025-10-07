using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaintSystemAPIVersionOne.Model;

public class PaintSeries
{
    public int Id { get; set; }
    [MaxLength(20), Required] public string Name { get; set; }
    [Required, MaxLength(50)] public string Description { get; set; }
    public DateTime CreatedTime { get; set; }

    [ForeignKey("PaintBrand")] public int PaintBrandId { get; set; } // 外键
    public PaintBrand PaintBrand { get; set; } // 导航属性
    
    
    public List<PaintProduct> PaintProducts { get; set; } = new List<PaintProduct>();
    
    public PaintSeries()
    {
    }

    public PaintSeries(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedTime = DateTime.Now;
    }
}