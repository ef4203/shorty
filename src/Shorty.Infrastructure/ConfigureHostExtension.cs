namespace Shorty.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shorty.Infrastructure.Persistence;

public static class ConfigureHostExtension
{
    public static IHost UseInfrastructureServices(this IHost app)
    {
        _ = app ?? throw new ArgumentNullException(nameof(app));

        app.UseAutomaticMigration();

        return app;
    }

    private static IHost UseAutomaticMigration(this IHost app)
    {
        _ = app ?? throw new ArgumentNullException(nameof(app));

        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

        if (context.Database.IsRelational())
        {
            context.Database.Migrate();
        }

        return app;
    }
}
