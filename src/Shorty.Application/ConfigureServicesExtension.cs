namespace Shorty.Application;

using System.Reflection;
using FluentValidation;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;
using Shorty.Application.Common.Behaviors;

public static class ConfigureServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        services.AddMediatorFromAssembly(typeof(ConfigureServicesExtension).Assembly);
        services.AddValidatorsFromAssembly(typeof(ConfigureServicesExtension).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }

    private static IServiceCollection AddMediatorFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        _ = services ?? throw new ArgumentNullException(nameof(services));

        services.AddMediatR(
            x =>
            {
                x.RegisterServicesFromAssembly(assembly);
                x.NotificationPublisherType = typeof(TaskWhenAllPublisher);
            });

        return services;
    }
}
