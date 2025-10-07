using PaintSystemAPIVersionOne.Enum;
using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class OrderSeeder : BaseSeeder<Order>
{
    protected override void AddSeedData(PaintDbContext context)
    {
        context.OrderTable.AddRange(
            new Order
            {
                Id = 1,
                TotalPrice = 120.50m,
                OrderStatus = OrderStatus.Pending,
                OrderReference = "ORD-20251007-001",
                CreatedAt = DateTime.Now,
                UserId = 1 // Alice
            },
            new Order
            {
                Id = 2,
                TotalPrice = 75.25m,
                OrderStatus = OrderStatus.Completed,
                OrderReference = "ORD-20251007-002",
                CreatedAt = DateTime.Now,
                UserId = 2 // Bob
            },
            new Order
            {
                Id = 3,
                TotalPrice = 200.00m,
                OrderStatus = OrderStatus.Confirmed,
                OrderReference = "ORD-20251007-003",
                CreatedAt = DateTime.Now,
                UserId = 3 // Carol
            },
            new Order
            {
                Id = 4,
                TotalPrice = 50.75m,
                OrderStatus = OrderStatus.Pending,
                OrderReference = "ORD-20251007-004",
                CreatedAt = DateTime.Now,
                UserId = 1 // Alice
            }
            
        );
    }
}