using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class PaintBrandSeeder : BaseSeeder<PaintBrand>
{
    protected override void AddSeedData(PaintDbContext context)
    {
        context.PaintBrandTable.AddRange(
            new PaintBrand
            {
                Id = 1,
                Name = "Dulux",
                Description = "Premium paint brand known.",
                CreatedAt = DateTime.Now
            },
            new PaintBrand
            {
                Id = 2,
                Name = "Taubmans",
                Description = "Reliable Australian paint .",
                CreatedAt = DateTime.Now
            },
            new PaintBrand
            {
                Id = 3,
                Name = "Haymes",
                Description = "Family-owned paint brand ",
                CreatedAt = DateTime.Now
            }
        );
    }
}