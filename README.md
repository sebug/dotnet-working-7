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
