using BoxFactoryInfrastructure.Repositories;
using BoxFactoryInfrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BoxFactoryInfrastructure.Extensions;

public static class BoxFactoryInfrastructureExtensions
{
    public static IServiceCollection UseBoxFactoryInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IBoxRepository, BoxRepository>();

        return services;
    }
}
