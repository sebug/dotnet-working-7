using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace DiSample;

public static class IHostBuilderExtensions
{
    public static IHostBuilder UseAutofacServiceProvider(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseServiceProviderFactory<ContainerBuilder>(
            new AutofacServiceProviderFactory()
        );
        return hostBuilder;
    }
}