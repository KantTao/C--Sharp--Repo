using PaintSystemAPIVersionOne.Model;
namespace PaintSystemAPIVersionOne.Data.Seeders;


public class UserSeeder : BaseSeeder<User>
{
    
    protected override void AddSeedData(PaintDbContext context)
    {
        context.UserTable.AddRange(
            new User { Id = 1, PhoneNumber = "0412345678", Email = "alice@example.com", Address = "123 Main St", DuluxAccountInfo = "DULUX001",CreatedAt = DateTime.Now },
            new User { Id = 2, PhoneNumber = "0498765432", Email = "bob@example.com", Address = "456 High St", DuluxAccountInfo = "DULUX002" ,CreatedAt = DateTime.Now},
            new User { Id = 3, PhoneNumber = "0433221122", Email = "carol@example.com", Address = "789 Park Ave", DuluxAccountInfo = "DULUX003",CreatedAt = DateTime.Now }
        );
        
    }
}