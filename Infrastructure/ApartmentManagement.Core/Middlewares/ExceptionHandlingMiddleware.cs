
using ApartmentManagement.Core.ResponseManager;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ApartmentManagement.Core.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UnauthorizedAccessException ex)
        {
            await HandleExceptionAsync(context, ex, 401);
        }
        catch (ArgumentException ex)
        {
            await HandleExceptionAsync(context, ex, 400);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, 500);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        BaseResponseModel response;

        switch (statusCode)
        {
            case 401:
                response = ResponseManager.ResponseManager.Unauthorized(exception.Message);
                break;
            case 400:
                response = ResponseManager.ResponseManager.BadRequest(exception.Message);
                break;
            case 500:
                response = ResponseManager.ResponseManager.InternalServerError(exception.Message);
                break;
            default:
                response = new BaseResponseModel
                {
                    Success = false,
                    Message = "An unexpected error occurred.",
                    StatusCode = statusCode
                };
                break;
        }

        var result = JsonConvert.SerializeObject(response);
        return context.Response.WriteAsync(result);
    }
}
