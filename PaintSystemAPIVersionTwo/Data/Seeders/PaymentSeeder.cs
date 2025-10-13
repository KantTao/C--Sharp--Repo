using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class PaymentSeeder : BaseSeeder<Payment>
{
    protected override void AddSeedData(PaintDbContext context)
    {
        context.PaymentTable.AddRange(
            new Payment
            {
                Id = 001,
                Amount = 250.00m,
                PaidAt = DateTime.Now,
                OrderId = 1 // 对应第1条订单
            },
            new Payment
            {
                Id = 002,
                Amount = 180.50m,
                PaidAt = DateTime.Now,
                OrderId = 2
            },
            new Payment
            {
                Id = 003,
                Amount = 320.75m,
                PaidAt = DateTime.Now,
                OrderId = 3
            },
            new Payment
            {
                Id = 004,
                Amount = 150.00m,
                PaidAt = DateTime.Now,
                OrderId = 4
            }
        );
    }
}