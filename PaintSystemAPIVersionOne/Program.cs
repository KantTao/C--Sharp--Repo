using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaintSystemAPIVersionOne.Data;
using PaintSystemAPIVersionOne.Data.Seeders;
using PaintSystemAPIVersionOne.Exceptions;
using PaintSystemAPIVersionOne.Repositories;
using PaintSystemAPIVersionOne.Services;
using PaintSystemAPIVersionOne.Validator;

namespace PaintSystemAPIVersionOne;

public class Program
{
    public static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        // Add services to the container.   解决无线循环关联数据。 
        // builder.Services.AddControllers().AddJsonOptions(x =>
        //     x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        //  PaintProductValidator
        builder.Services.AddControllers()
            .AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<OrderCreateRequestValidator>()

            )
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        
        
        
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
        
        //AutoMapper Setting 
        builder.Services.AddAutoMapper(typeof(Program));
        
        
        //格式化返回验证错误 （不经过全局异常中间件）但是返回信息格式 一致
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            // 当模型校验失败时触发
            options.InvalidModelStateResponseFactory = context =>
            {
                // 收集所有错误信息
                var errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .SelectMany(kvp => kvp.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                // 构造统一响应
                var response = new  FormattedResponse<object>(
                    message: string.Join("; ", errors), // 拼成一条消息
                    isSuccess: false,
                    statusCode: 400
                );

                // 返回 BadRequestResult
                return new BadRequestObjectResult(response);
            };
        });
        
        
        
        var app = builder.Build();
        
        //注册全局异常中间件（放在最前面） 
       //Controller 或 Service 抛异常 → 自动被 Middleware 捕获
       //日志打印 → _logger.LogError 记录异常和堆栈
       //返回 JSON → 前端收到统一的 { StatusCode, Message, IsSuccess, RequestTime }
       //可扩展 → 可以增加自定义 BusinessException、第三方监控、告警等
        app.UseMiddleware<GlobalExceptionMiddleware>();
        
        
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