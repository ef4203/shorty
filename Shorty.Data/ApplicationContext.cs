namespace Shorty.Data
{
    using Microsoft.EntityFrameworkCore;
    using Shorty.Entities;

    /// <summary>
    /// The application database context for managed access to the database.
    /// </summary>
    /// <seealso cref="DbContext" />
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the shorthands.
        /// </summary>
        /// <value>
        /// The shorthands.
        /// </value>
        public DbSet<Shorthand> Shorthands { get; set; }
    }
}
