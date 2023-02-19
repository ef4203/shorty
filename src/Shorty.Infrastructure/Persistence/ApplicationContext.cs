namespace Shorty.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Shorty.Application.Common.Abstraction;
using Shorty.Domain;

[UsedImplicitly]
internal sealed class ApplicationContext : DbContext, IApplicationContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Shorthand> Shorthands { get; set; } = default!;
}
