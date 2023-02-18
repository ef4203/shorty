namespace Shorty.Web;

using Serilog;
using Shorty.Application;
using Shorty.Infrastructure;
using Shorty.Web.Filter;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddRazorPages();
        builder.Services.AddControllers();
        builder.Services.AddControllersWithViews(
            o => { o.Filters.Add<ApiExceptionFilterAttribute>(); });

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices();

        var app = builder.Build();

        app.MapControllers();
        app.MapRazorPages();
        app.UseRouting();
        app.UseFileServer();

        app.UseInfrastructureServices();

        app.Run();
    }
}
