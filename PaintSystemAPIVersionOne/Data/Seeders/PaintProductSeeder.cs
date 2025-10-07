using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class PaintProductSeeder : BaseSeeder<PaintProduct>
{
    protected override void AddSeedData(PaintDbContext context)
    {
        
        context.PaintProductTable.AddRange(
            new PaintProduct
            {
                Id = 1,
                Name = "Dulux Wash & Wear Matte White",
                PricePerLitre = 35.99m,
                Color = "White",
                GlossLevel = "Matte",
                BaseType = "Water-Based",
                Size = "4L",
                Stock = 120,
                CreatedAt = DateTime.Now,
                PaintBrandId = 1, // Dulux
                PaintSeriesId = 1, // Wash & Wear
                PaintCategoryId = 1 // Interior Paints
            },
            
            
            
            new PaintProduct
            {
                Id = 2,
                Name = "Dulux Wash & Wear Low Sheen Grey",
                PricePerLitre = 37.50m,
                Color = "Grey",
                GlossLevel = "Low Sheen",
                BaseType = "Water-Based",
                Size = "10L",
                Stock = 85,
                CreatedAt = DateTime.Now,
                PaintBrandId = 1, // Dulux
                PaintSeriesId = 1, // Wash & Wear
                PaintCategoryId = 1 // Interior Paints
            },
            new PaintProduct
            {
                Id = 3,
                Name = "Taubmans Endure Gloss Black",
                PricePerLitre = 42.90m,
                Color = "Black",
                GlossLevel = "Gloss",
                BaseType = "Oil-Based",
                Size = "4L",
                Stock = 60,
                CreatedAt = DateTime.Now,
                PaintBrandId = 2, // Taubmans
                PaintSeriesId = 2, // Endure
                PaintCategoryId = 2 // Exterior Paints
            },
            new PaintProduct
            {
                Id = 4,
                Name = "Haymes Expressions Satin Blue",
                PricePerLitre = 39.75m,
                Color = "Blue",
                GlossLevel = "Satin",
                BaseType = "Water-Based",
                Size = "2L",
                Stock = 100,
                CreatedAt = DateTime.Now,
                PaintBrandId = 3, // Haymes
                PaintSeriesId = 3, // Expressions
                PaintCategoryId = 3 // Wood Finishes
            }
        );
    }
}