using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class PaintSeriesSeeder : BaseSeeder<PaintSeries>
{
    protected override void AddSeedData(PaintDbContext context)
    {
        context.PaintSeriesTable.AddRange(
            new PaintSeries
            {
                Id = 1,
                Name = "Wash & Wear",
                Description = "Durable interior paint from Dulux.",
                CreatedTime = DateTime.Now,
                PaintBrandId = 1 // Dulux
            },
            new PaintSeries
            {
                Id = 2,
                Name = "Endure",
                Description = "Premium interior paint by Taubmans.",
                CreatedTime = DateTime.Now,
                PaintBrandId = 2 // Taubmans
            },
            new PaintSeries
            {
                Id = 3,
                Name = "Expressions",
                Description = "Stylish paint collection by Haymes.",
                CreatedTime = DateTime.Now,
                PaintBrandId = 3 // Haymes
            }
        );
    }
}