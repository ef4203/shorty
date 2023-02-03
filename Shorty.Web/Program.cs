namespace Shorty.Web;

using Microsoft.EntityFrameworkCore;
using Shorty.Data;

/// <summary>
///     Class which contains the entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    ///     Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddLogging();
        builder.Services.AddDbContext<ApplicationContext>(
            o => o.UseSqlite("Data Source=data.db"));
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.MapControllers();
        app.UseFileServer();

        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        db.Database.Migrate();

        app.Run();
    }
}
