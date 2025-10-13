using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;
//PaintCategoriesSeeder

public class PaintCategoriesSeeder : BaseSeeder<PaintCategories>
{
    protected override void AddSeedData(PaintDbContext context)
    {
        context.PaintCategoryTable.AddRange(
            new PaintCategories
            {
                Id = 1,
                Description = "Interior Paints",
                CreatedTime = DateTime.Now
            },
            new PaintCategories
            {
                Id = 2,
                Description = "Exterior Paints",
                CreatedTime = DateTime.Now
            },
            new PaintCategories
            {
                Id = 3,
                Description = "Wood Finishes",
                CreatedTime = DateTime.Now
            }
        );
    }
}