namespace MiddlewareSample;

public static class StopWatchExtensions
{
    public static IApplicationBuilder AddStopWatch(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<StopwatchMiddleware>();
        return builder;
    }
}