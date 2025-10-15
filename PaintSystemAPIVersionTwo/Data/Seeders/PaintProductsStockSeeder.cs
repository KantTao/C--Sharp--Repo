using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class PaintProductsStockSeeder: BaseSeeder<PaintProductsStock>
{
    
    
    protected override void AddSeedData(PaintDbContext context)
    {
        context.PaintProductsStockTable.AddRange(
            new PaintProductsStock
            {   Id = 1 ,
                StockQuantity = 100,
                PaintProductId = 1,
                CreatedAt = DateTime.Now
            },
            new PaintProductsStock
            {
                Id = 2 ,
                StockQuantity = 50,
                PaintProductId = 2,
                CreatedAt = DateTime.Now
            },
            new PaintProductsStock
            {   
                Id = 3 ,
                StockQuantity = 75,
                PaintProductId = 3,
                CreatedAt = DateTime.Now
            },
            new PaintProductsStock
            {   
                Id = 4 ,
                StockQuantity = 200,
                PaintProductId = 4,
                CreatedAt = DateTime.Now
            }
        );
        
    }
}