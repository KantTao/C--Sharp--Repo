using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Data;
using PaintSystemAPIVersionOne.Data.Seeders;
using PaintSystemAPIVersionOne.Repositories;
using PaintSystemAPIVersionOne.Services;

namespace PaintSystemAPIVersionOne;

public class Program
{
    public static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        // Add services to the container.   解决无线循环关联数据。 
        builder.Services.AddControllers().AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //builder.Configuration.GetConnectionString("PaintDb") 就是找到appsetting.json文件中的配置链接字符串
        builder.Services.AddDbContext<PaintDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("PaintDb"))
        );
        
        //Dependent Injection using scop
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<UserService>();
        
        
        // All Repository and Service DI 
        builder.Services.AddRepositories(); // 注册所有 Repository
        builder.Services.AddServices();     // 注册所有 Service
        
        
        var app = builder.Build();
        
        //Seeder 
        DbInitializer.Initialize(app.Services);
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        

        
        
        
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}