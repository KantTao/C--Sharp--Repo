using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Data.Seeders;

public class ExSeeder : BaseSeeder<User>
{
    
    protected override void AddSeedData(PaintDbContext context)
    {
        context.UserTable.AddRange(
   
        );
        
    }
}