using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class StockTransactionSeeder : BaseSeeder<StockTransaction>
{
    protected override void AddSeedData(PaintDbContext context)
    {
        context.StockTransactionTable.AddRange(
                new StockTransaction
                    { Id = 1, ReferenceOrderId = 1, PaintProductId = 1, Quantity = 10, CreatedAt = DateTime.Now },
                new StockTransaction
                    { Id = 2, ReferenceOrderId = 2, PaintProductId = 2, Quantity = 5, CreatedAt = DateTime.Now },
                new StockTransaction
                    { Id = 3, ReferenceOrderId = 3, PaintProductId = 3, Quantity = 8, CreatedAt = DateTime.Now },
                new StockTransaction
                    { Id = 4, ReferenceOrderId = 4, PaintProductId = 4, Quantity = 12, CreatedAt = DateTime.Now }
            );
            
    }
}