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

#pragma warning disable CA1305
        Log.Logger = new LoggerConfiguration()
#pragma warning restore CA1305
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddControllers();
        builder.Services.AddControllersWithViews(
            o => { o.Filters.Add<ApiExceptionFilterAttribute>(); });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();
        app.MapRazorPages();
        app.MapBlazorHub();
        app.MapFallbackToPage("/Index");
        app.UseRouting();
        app.UseStaticFiles();

        app.UseInfrastructureServices();

        app.Run();
    }
}
