namespace Shorty.Application.Common.Abstraction;

using Microsoft.EntityFrameworkCore;
using Shorty.Domain;

public interface IApplicationContext
{
    DbSet<Shorthand> Shorthands { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    void RemoveRange(IEnumerable<object> entities);
}
