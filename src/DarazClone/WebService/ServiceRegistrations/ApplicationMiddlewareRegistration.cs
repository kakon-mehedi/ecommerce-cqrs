using DarazClone.Core.Services;


namespace DarazClone.WebService.ServiceRegistrations;

public static class ApplicationMiddlewareRegistration
{
    public static IApplicationBuilder AddApplicationMiddleware(this IApplicationBuilder app, IHostEnvironment environment)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseMiddleware<BlockPathMiddleware>();
        app.UseMiddleware<RequestTimingMiddleware>();
        app.UseMiddleware<RequestLoggingMiddleware>();
        
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        return app;
    }
}