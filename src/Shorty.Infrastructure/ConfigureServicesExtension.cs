namespace Shorty.Infrastructure;

using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shorty.Application.Common.Abstraction;
using Shorty.Infrastructure.Persistence;
using Shorty.Infrastructure.Scheduling;

public static class ConfigureServicesExtension
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ApplicationContext>(
            o => o.UseSqlite("Data Source=data.db"));

        services.AddHangfireConfiguration();

        services.AddTransient<IApplicationContext, ApplicationContext>();
        services.AddTransient<IJobClient, JobClient>();

        return services;
    }

    private static void AddHangfireConfiguration(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        services.AddHangfire(
            o =>
            {
                o.UseSimpleAssemblyNameTypeSerializer();
                o.UseRecommendedSerializerSettings();
                o.UseMemoryStorage();
            });

        services.AddHangfireServer();
    }
}
