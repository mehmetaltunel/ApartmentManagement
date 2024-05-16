using Microsoft.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ApartmentManagement.Core.Middlewares;

public class RequestAndResponseOpenTelemetryMiddleware
{
    private readonly RequestDelegate _next;
    private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

    public RequestAndResponseOpenTelemetryMiddleware(RequestDelegate next)
    {
        _next = next;
        _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        await AddRequestBodyContentToActivityTag(httpContext);
        await AddResponseBodyContentToActivityTag(httpContext);
    }

    private async Task AddRequestBodyContentToActivityTag(HttpContext context)
    {
        context.Request.EnableBuffering();
        var requestBodyStreamer = new StreamReader(context.Request.Body);
        var requestBodyContent = await requestBodyStreamer.ReadToEndAsync();
        Activity.Current.SetTag("http.request.body", requestBodyContent);
        context.Request.Body.Position = 0;
    }

    private async Task AddResponseBodyContentToActivityTag(HttpContext context)
    {
        var originalResponse = context.Response.Body;
        await using var responseBodyMemoryStream = _recyclableMemoryStreamManager.GetStream();
        context.Response.Body = responseBodyMemoryStream;
        await _next(context);
        responseBodyMemoryStream.Position = 0;
        var responseBodyStreamReader = new StreamReader(responseBodyMemoryStream);
        var responseBodyContent = await responseBodyStreamReader.ReadToEndAsync();
        Activity.Current.SetTag("http.response.body", responseBodyContent);
        responseBodyMemoryStream.Position = 0;
        await responseBodyMemoryStream.CopyToAsync(originalResponse);
    }

}