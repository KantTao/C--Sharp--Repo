using PaintSystemAPIVersionOne.Data;

namespace PaintSystemAPIVersionOne.Interface.Data.Seeders;

public interface IEntitySeeder
{
    void Seed(PaintDbContext context, ILogger logger);
}
