var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) => {
    //await context.Response.WriteAsync("===");
    await next();
    await context.Response.WriteAsync("^^^");
});

app.MapGet("/", () => "Hello .NETworking!");

app.Run();
