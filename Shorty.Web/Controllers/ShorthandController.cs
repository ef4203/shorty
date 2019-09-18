namespace Shorty.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Shorty.Data;
    using Shorty.Entities;

    /// <summary>
    /// Controller which provides enpoints for managing shorthands.
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [ApiController]
    [Route("_")]
    public class ShorthandController : ControllerBase
    {
        /// <summary>
        /// The application database context.
        /// </summary>
        private readonly ApplicationContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShorthandController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="context"/> is null.</exception>
        public ShorthandController(ApplicationContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>The destination to be redirected to.</returns>
        [HttpGet("{url}")]
        public async Task<ActionResult> Get([FromRoute]string url)
        {
            var result = await this.context.FindAsync<Shorthand>(url);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Redirect(result.Destination);
        }

        /// <summary>
        /// Posts the specified data. And also removes shorthands which are older than one month.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The creation result.</returns>
        [HttpPost]
        public async Task<string> Post([FromBody] Shorthand data)
        {
            data.DateAdded = DateTime.Now;
            data.URL = Guid.NewGuid()
                .ToString("n")
                .Substring(0, 5);

            var aMonthAgo = DateTime.Now.AddMonths(-1);
            var toRemove = await this.context.Shorthands
                .Where(x => x.DateAdded < aMonthAgo)
                .ToListAsync();

            this.context.RemoveRange(toRemove);
            this.context.Add<Shorthand>(data);
            await this.context.SaveChangesAsync();

            return data.URL;
        }
    }
}
