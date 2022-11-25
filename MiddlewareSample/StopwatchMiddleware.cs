using System.Diagnostics;

namespace MiddlewareSample;

public class StopwatchMiddleware
{
    private readonly RequestDelegate _next;

    public StopwatchMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var s = new Stopwatch();
        s.Start();
        await _next(context);
        s.Stop();
        await context.Response.WriteAsync("^^^ " + s.Elapsed);
    }
}