namespace PaintSystemAPIVersionOne.Services;


public static class ServiceModule
{
    public static void AddServices(this IServiceCollection services)
    {
        
        services.AddScoped<UserService>();
        services.AddScoped<PaintProductService>();
        
    }
}