namespace Shorty.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Shorty.Data;

    /// <summary>
    /// Class to configure ASP.NET and EntityFramework.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(o => o.UseSqlite(@"Data Source=data.db"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            this.InitializeDatabase(app);
            app.UseFileServer();
            app.UseMvc();
        }

        /// <summary>
        /// Initializes the database. Creates the database if necessary and applies all missing migrations.
        /// </summary>
        /// <param name="app">The application.</param>
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (IServiceScope scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    dbContext.Database.Migrate();
                }
            }
        }
    }
}
