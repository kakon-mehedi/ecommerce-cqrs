using Microsoft.AspNetCore.Http;

namespace DarazClone.Core.Services;

public class BlockPathMiddleware: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path == "/blocked")
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("This path is blocked!");
            return; // Short-circuit the pipeline
        }

        await next(context);
    }
}