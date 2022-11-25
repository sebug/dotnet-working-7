using System.Diagnostics;
using MiddlewareSample;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<StopwatchMiddleware>();

app.MapGet("/", () => "Hello .NETworking!");

app.Run();
