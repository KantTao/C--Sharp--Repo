using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class OrderPaintProductDetailSeeder
{
    
    public void SeedOrderPaintProductDetails(PaintDbContext context)
    {
        if (!context.OrderPaintProductTable.Any())
        {
            context.OrderPaintProductTable.AddRange(
                new OrderPaintProductDetail { OrderId = 1, PaintProductId = 1, Quantity = 20 },
                new OrderPaintProductDetail { OrderId = 1, PaintProductId = 2, Quantity = 11 },
                new OrderPaintProductDetail { OrderId = 2, PaintProductId = 3, Quantity = 40 },
                new OrderPaintProductDetail { OrderId = 3, PaintProductId = 4, Quantity = 12 },
                new OrderPaintProductDetail { OrderId = 4, PaintProductId = 1, Quantity = 33 }
            );
            context.SaveChanges();
        }
    }
}