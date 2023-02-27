namespace Shorty.Application.Common.Abstraction;

using System.Linq.Expressions;

public interface IJobClient
{
    void AddOrUpdate(string recurringJobId, Expression<Func<Task>> methodCall, string cronPattern);
}
