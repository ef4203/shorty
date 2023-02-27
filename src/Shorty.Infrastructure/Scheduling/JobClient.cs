namespace Shorty.Infrastructure.Scheduling;

using System.Linq.Expressions;
using Hangfire;
using Shorty.Application.Common.Abstraction;

public class JobClient : IJobClient
{
    private readonly IRecurringJobManager recurringJobManager;

    public JobClient(IRecurringJobManager recurringJobManager)
    {
        this.recurringJobManager =
            recurringJobManager ?? throw new ArgumentNullException(nameof(recurringJobManager));
    }

    public void AddOrUpdate(string recurringJobId, Expression<Func<Task>> methodCall, string cronPattern)
    {
        this.recurringJobManager.AddOrUpdate(recurringJobId, methodCall, cronPattern);
    }
}
