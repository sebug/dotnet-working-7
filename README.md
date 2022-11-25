# .NET Working - ASP.NET 7 Customization
http://asp.net-hacker.rocks

## Logging
Add -n for the main namespace

Build your own logger.

Snippets here: https://gist.github.com/JuergenGutsch

When adding loggers, the standard ones stay around.

## Configuring Configuration
$"appsettings.{env.EnvironmentName}.json"

environment variables override.

## DI
If you add your own container, then the standard one will continue working.

## Certificates
Load manually from Kestrel.

    options.Listen(IPAddress.Loopback, 5001, options => {
        listenOptions.UseHttps("cert.pfx", pwd);
    });


## Hosting
When using nginx, have to specify proxy.

https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-7.0

## Hosted Services
dotnet new worker

Then publish as service: https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service

