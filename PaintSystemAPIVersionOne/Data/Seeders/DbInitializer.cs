using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Interface.Data.Seeders;
namespace PaintSystemAPIVersionOne.Data.Seeders;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<PaintDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<object>>();
        
        dbContext.Database.Migrate();
        
        var seeders = new List<IEntitySeeder>
        {
            new UserSeeder(),
            new PaintBrandSeeder(),
            new PaintCategoriesSeeder(),
            new PaintSeriesSeeder(),
            new PaintProductSeeder(),
            new OrderSeeder(),
            new PaintProductsStockSeeder(),
            new PaymentSeeder(),
            new StockTransactionSeeder()
            
        };
        
        
        
        foreach (var seeder in seeders)
        {
            seeder.Seed(dbContext, logger);
        }
        
        
        
        // 单独调用中间表 Seeder
        var orderPaintSeeder = new OrderPaintProductDetailSeeder();
        orderPaintSeeder.SeedOrderPaintProductDetails(dbContext );
        
        
    }
}