using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ErrroHandlingMiddleware {

    private readonly RequestDelegate _next;

    public ErrroHandlingMiddleware(RequestDelegate next) {

        _next = next;
    }

    public async Task Invoke(HttpContext context) {

        try {
            
            await _next(context);
        }
        catch(Exception ex) {

            await HandleExcpetionAsync(context, ex);
        }

    }

    private static Task HandleExcpetionAsync(HttpContext context, Exception ex) {

        var code = HttpStatusCode.InternalServerError;
        
        if(ex is ArgumentNullException) {

            code = HttpStatusCode.NotFound;
        }
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        
        return context.Response.WriteAsync(JsonSerializer.Serialize(new {error = ex.Message}));
    }
}