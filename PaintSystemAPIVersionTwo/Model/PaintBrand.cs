using System.ComponentModel.DataAnnotations;

namespace PaintSystemAPIVersionOne.Model;

public class PaintBrand
{
    
    
    
    public int Id { get; set; }
    [MaxLength(30)] [Required] public string Name { get; set; }
    [MaxLength(50)] [Required] public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    //PaintBrand ------> PaintSeries   (1-----> Many)
    public List<PaintSeries> PaintSeriesList { get; set; } = new List<PaintSeries>();
    //PaintBrand ------> PaintProduct      (1-----> Many)
    public List<PaintProduct> PaintProductList { get; set; } = new List<PaintProduct>();
    

    public PaintBrand()
    {
    }

    public PaintBrand(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }
}