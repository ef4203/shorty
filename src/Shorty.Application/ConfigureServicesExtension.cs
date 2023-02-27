namespace Shorty.Application;

using System.Reflection;
using FluentValidation;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using Shorty.Application.Common.Abstraction;
using Shorty.Application.Common.Behaviors;
using Shorty.Application.Common.Mapping;

public static class ConfigureServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        services.AddMediatorFromAssembly(typeof(ConfigureServicesExtension).Assembly);
        services.AddValidatorsFromAssembly(typeof(ConfigureServicesExtension).Assembly);
        services.AddJobsFromAssembly(typeof(ConfigureServicesExtension).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddMappings();

        return services;
    }

    private static void AddJobsFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));
        _ = assembly ?? throw new ArgumentNullException(nameof(assembly));

        var jobs = assembly
            .GetTypes()
            .Where(x => x.IsClass && x.GetInterface(nameof(IJob)) != null);

        foreach (var jobType in jobs)
        {
            services.AddTransient(jobType);
        }
    }

    private static void AddMediatorFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));
        _ = assembly ?? throw new ArgumentNullException(nameof(assembly));

        services.AddMediatR(
            x =>
            {
                x.RegisterServicesFromAssembly(assembly);
                x.NotificationPublisherType = typeof(TaskWhenAllPublisher);
            });
    }

    private static void AddMappings(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        ShorthandMappingConfiguration.Apply();
    }
}
