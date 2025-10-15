using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace PaintSystemAPIVersionOne.Exceptions;

//Global Exception Middleware
public class GlobalExceptionMiddleware
{   
    //
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // 调用下一个中间件/Controller
            await _next(context);
        }
        catch (Exception ex)
        {
            // 捕获未处理异常
            await HandleExceptionAsync(context, ex);
        }
    }
    
    
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = GetStatusCode(exception);

        // 记录异常日志
        _logger.LogError(exception, "Unhandled exception occurred");

        // 构造统一响应
        var response = new FormattedResponse<object>(
            message: exception.Message,
            isSuccess: false,
            statusCode: context.Response.StatusCode
        );

        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
    
    
    
    private int GetStatusCode(Exception exception)
    {
        // 可以根据异常类型自定义状态码
        return exception switch
        {
            ArgumentException => 400,
            KeyNotFoundException => 404,
            DbUpdateException => 500,
            InvalidOperationException => 500,
            _ => 500
        };
    }
    
}