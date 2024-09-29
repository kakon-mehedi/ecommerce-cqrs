using System.Collections.Immutable;
using Microsoft.AspNetCore.Http;

namespace DarazClone.Core.Services;


public class ExceptionHandlingMiddleware: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        Console.WriteLine($"Exception: {exception.Message}");
        Console.WriteLine($"StackTrace", exception.StackTrace);

        var errorResponse = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode = 500, // Internal Server Error
            Message = "An unexpected error occurred.",
            DetailedMessage = exception.Message, // Optionally include stack trace for detailed errors
            StackTrace = exception.StackTrace?.ToString()
        };

        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(errorResponse));
    }
}

public class ErrorResponse
{
    public int StatusCode { get; set; } = 500;
    public string Message { get; set; } = string.Empty;
    public string DetailedMessage { get; set; } = string.Empty; // Optional, you can include stack trace or error details
    public dynamic? StackTrace { get; set; }
}
