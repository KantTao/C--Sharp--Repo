namespace PaintSystemAPIVersionOne.Repositories;

public static class RepositoryModule
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<UserRepository>();
        services.AddScoped<PaintProductRepository>();
        services.AddScoped<OrderRepository>();
        services.AddScoped<PaintStockRepository>();
    }
}


