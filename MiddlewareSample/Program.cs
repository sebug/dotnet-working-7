using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) => {
    var s = new Stopwatch();
    s.Start();
    await next(context);
    s.Stop();
    await context.Response.WriteAsync("^^^ " + s.Elapsed);
});

app.MapGet("/", () => "Hello .NETworking!");

app.Run();
