using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemAPI.Exceptions;


public class GlobalExceptionHandler
{
    private ILogger<GlobalExceptionHandler> _logger;
    
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    
    

    public async Task HandleExceptionAsync(HttpContext context)
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (exceptionHandlerFeature == null) return; //没有异常 直接返回 不做任何事

        var exception = exceptionHandlerFeature.Error;//获取具体异常对象
        
        context.Response.ContentType = "application/json";//提前设定 一会返回的错误是Json格式
        context.Response.StatusCode = GetStatusCode(exception);//
        
        //构造响应对象
        var response = new FormattedResponse(exception.Message, false, context.Response.StatusCode);
        //返回响应给客户端 JsonSerializer.Serialize(response) 把 FormattedResponse 对象转换成 JSON 字符串
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        
        
    }
    
    
    private int GetStatusCode(System.Exception exception)
    {
        if (exception is ArgumentException) return 400;
        if (exception is DbUpdateException) return 500;
        if (exception is InvalidOperationException) return 500;
        if (exception is KeyNotFoundException) return 400;
        if (exception is NotFoundException) return 404;
        _logger.LogError($" error;{exception.Message}");
        return 500;
    } 
    
    
}