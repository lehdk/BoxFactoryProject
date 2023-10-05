using BoxFactoryInfrastructure.Configuration;
using BoxFactoryInfrastructure.Repositories;
using BoxFactoryInfrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BoxFactoryInfrastructure.Extensions;

public static class BoxFactoryInfrastructureExtensions
{
    public static IServiceCollection UseBoxFactoryInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("database");
        ArgumentException.ThrowIfNullOrEmpty(configuration.GetConnectionString("database"));
        var dbConnectionStringObject = new DatabaseConnectionString(connectionString!);
        services.TryAddSingleton(dbConnectionStringObject);

        services.AddTransient<IBoxRepository, BoxRepository>();
        services.AddTransient<IBoxOrderRepository, BoxOrderRepository>();

        return services;
    }
}
