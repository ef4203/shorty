namespace Shorty.Infrastructure;

using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shorty.Application.Common.Abstraction;
using Shorty.Infrastructure.Persistence;

public static class ConfigureHostExtension
{
    public static WebApplication UseInfrastructureServices(this WebApplication app)
    {
        _ = app ?? throw new ArgumentNullException(nameof(app));

        app.UseAutomaticMigration();
        app.UseHangfireDashboard();
        app.UseJobs();

        return app;
    }

    private static void UseAutomaticMigration(this WebApplication app)
    {
        _ = app ?? throw new ArgumentNullException(nameof(app));

        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        if (context.Database.IsRelational())
        {
            context.Database.Migrate();
        }
    }

    private static void UseJobs(this WebApplication app)
    {
        _ = app ?? throw new ArgumentNullException(nameof(app));

        using var scope = app.Services.CreateScope();
        var backgroundJobService = scope.ServiceProvider.GetRequiredService<IJobClient>();

        var jobs = typeof(IJob).Assembly
            .GetTypes()
            .Where(x => x.IsClass && x.GetInterface(nameof(IJob)) != null);

        foreach (var type in jobs)
        {
            var jobInstance = (IJob)scope.ServiceProvider.GetRequiredService(type);
            backgroundJobService.AddOrUpdate(
                type.Name,
                () => jobInstance.Handle(),
                jobInstance.CronPattern);
        }
    }
}
