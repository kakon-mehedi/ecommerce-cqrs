using Microsoft.AspNetCore.Http;

namespace DarazClone.Core.Services;


public class RequestLoggingMiddleware: IMiddleware
{
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine($"Request: {context.Request.Path}");
        
        await next(context);
        
        Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
    }
}