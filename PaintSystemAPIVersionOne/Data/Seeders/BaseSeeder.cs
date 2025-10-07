
using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Data;
using PaintSystemAPIVersionOne.Interface.Data.Seeders;

public abstract class BaseSeeder<T> : IEntitySeeder where T : class
{
    public void Seed(PaintDbContext context, ILogger logger)
    {
        if (!context.Set<T>().Any())
        {
            logger.LogInformation($"Seeding {typeof(T).Name}...");
            var tableName = context.Model.FindEntityType(typeof(T))?.GetTableName();
            
            using var transaction = context.Database.BeginTransaction();
            
            context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}] ON");
            
            AddSeedData(context);
            context.SaveChanges();
            
            context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}] OFF");
            
            transaction.Commit();
        }
        else
        {
            logger.LogInformation($"{typeof(T).Name} already exists. Skipping.");
        }
    }
    
    protected abstract void AddSeedData(PaintDbContext context);
}