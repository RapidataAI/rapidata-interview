using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Rapidata.Cli;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureCliServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}
