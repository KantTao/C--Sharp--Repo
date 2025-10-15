using PaintSystemAPIVersionOne.Model;

namespace PaintSystemAPIVersionOne.Services;


public static class ServiceModule
{
    public static void AddServices(this IServiceCollection services)
    {
        
        services.AddScoped<UserService>();
        services.AddScoped<PaintProductService>();
        services.AddScoped<OrderService>();
        services.AddScoped<PaintProductStockService>();
        
    }
}