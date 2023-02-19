namespace Shorty.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shorty.Application.Common.Abstraction;
using Shorty.Infrastructure.Persistence;

public static class ConfigureServicesExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ApplicationContext>(
            o => o.UseSqlite("Data Source=data.db"));
        services.AddTransient<IApplicationContext, ApplicationContext>();

        return services;
    }
}
