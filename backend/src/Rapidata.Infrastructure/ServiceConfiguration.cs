using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Rapidata.Infrastructure;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}
