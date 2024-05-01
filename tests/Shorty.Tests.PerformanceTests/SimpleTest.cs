namespace Shorty.Tests.PerformanceTests;

using BenchmarkDotNet.Attributes;
using Shorty.Application.Common.Mapping;
using Shorty.Domain;

public class SimpleTest
{
    [Benchmark]
    public void MapperTests()
    {
        var obj = new Shorthand
        {
            Url = "https://www.google.com",
            DateAdded = DateTime.Now,
            ExpiresAfterDays = 30,
        };
        
        ShorthandMappingConfiguration.ComputeExpirationDate(obj);
    }
}
