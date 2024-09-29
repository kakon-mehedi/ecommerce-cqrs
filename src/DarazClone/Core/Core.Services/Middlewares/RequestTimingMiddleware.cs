using Microsoft.AspNetCore.Http;

namespace DarazClone.Core.Services;


public class RequestTimingMiddleware: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var startTime = DateTime.UtcNow;
        await next(context);
        var endTime = DateTime.UtcNow;
        
        var processingTime = endTime - startTime;
        Console.WriteLine($"Request processing time: {processingTime.TotalMilliseconds} ms");
    }
}