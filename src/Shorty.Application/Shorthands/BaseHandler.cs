namespace Shorty.Application.Shorthands
{
    using Shorty.Application.Common.Abstraction;
    using System;

    internal class BaseHandler
    {
        protected readonly IApplicationContext dbContext;

        internal BaseHandler(IApplicationContext dbContext)
        {
            this.dbContext = dbContext 
                ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
