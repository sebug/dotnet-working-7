using System.Diagnostics;
using MiddlewareSample;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.AddStopWatch();

app.MapGet("/", () => "Hello .NETworking!");

app.Run();
