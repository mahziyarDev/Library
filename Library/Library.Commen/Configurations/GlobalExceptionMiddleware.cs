
using System.Net;
using System.Text.Json;
using Library.Common.Exception;
using Microsoft.AspNetCore.Http;

namespace Library.Common.Configurations;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (System.Exception ex)
        {
            // httpContext.Response.Redirect("/Error");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, System.Exception ex)
    {
        HttpStatusCode status;

        var stackTrace = string.Empty;
        var message = "";
        var exceptionType = ex.GetType();

        if (exceptionType == typeof(NotFountException))
        {
            message = ex.Message;
            status = HttpStatusCode.NotFound;
            stackTrace = ex.StackTrace;
        }
        else if (exceptionType == typeof(BadRequestException))
        {
            message = ex.Message;
            status = HttpStatusCode.BadRequest;
            stackTrace = ex.StackTrace;
        }
        else if (exceptionType == typeof(ServerException))
        {
            message = ex.Message;
            status = HttpStatusCode.InternalServerError;
            stackTrace = ex.StackTrace;
        }

        var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
        context.Response.ContentType = "application/json;";
        context.Response.StatusCode = int.Parse(nameof(status));
        return context.Response.WriteAsync(exceptionResult);


    }
}