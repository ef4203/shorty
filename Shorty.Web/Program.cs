namespace Shorty.Web;

using Microsoft.EntityFrameworkCore;
using Serilog;
using Shorty.Application;
using Shorty.Application.Common.Abstraction;
using Shorty.Infrastructure;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logging.
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddControllers();
        builder.Services.AddLogging();
        builder.Services.AddControllersWithViews();
        builder.Services.AddApplicationServices();

        builder.Services.AddDbContext<ApplicationContext>(
            o => o.UseSqlite("Data Source=data.db"));
        builder.Services.AddTransient<IApplicationContext, ApplicationContext>();

        var app = builder.Build();

        app.MapControllers();
        app.UseFileServer();

        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        db.Database.Migrate();

        app.Run();
    }
}
