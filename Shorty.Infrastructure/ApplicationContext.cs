namespace Shorty.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Shorty.Application.Common.Abstraction;
using Shorty.Domain;

public class ApplicationContext : DbContext, IApplicationContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Shorthand> Shorthands { get; set; }
}
