using BoxFactoryApplication.Services;
using BoxFactoryApplication.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BoxFactoryApplication.Extensions;

public static class BoxFactoryApplicationExtensions
{
    public static IServiceCollection UseBoxFactoryServices(this IServiceCollection services)
    {
        services.AddTransient<IBoxService, BoxService>();

        return services;
    }
}
