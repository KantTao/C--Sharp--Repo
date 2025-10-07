using System.ComponentModel.DataAnnotations;

namespace PaintSystemAPIVersionOne.Model;

public class PaintCategories
{
    public int Id { get; set; }
    [Required, MaxLength(50)] public string Description { get; set; }
    public DateTime CreatedTime { get; set; }
    
    public List<PaintProduct> PaintProducts{ get; set; } = new List<PaintProduct>();
    
    
    public PaintCategories()
    {
    }

    public PaintCategories(string description)
    {
        Description = description;
        CreatedTime = DateTime.Now;
    }
}