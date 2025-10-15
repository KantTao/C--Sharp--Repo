using System.ComponentModel.DataAnnotations;
namespace PaintSystemAPIVersionOne.DTO;

public class PaintProductRequest
{   
    
    [MaxLength(50)] 
    public string? name { get; set; }
    [Required]
    public decimal PricePerLitre { get; set; }
    public string color { get; set; }
    public string glossLevel { get; set; }
    public string baseType { get; set; }
    public string size { get; set; }
    public int  stock { get; set; }
    public int  paintBrandId { get; set; }
    public int  paintSeriesId { get; set; }
    public int  paintCategoryId { get; set; }
    

}