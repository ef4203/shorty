namespace Shorty.Tests.PerformanceTests;

using BenchmarkDotNet.Attributes;
using Mapster;
using Shorty.Application.Common.Mapping;
using Shorty.Application.Shorthands.Queries.GetAllShorthands;
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
        
        ShorthandMappingConfiguration.Apply();
        obj.Adapt<ShorthandDto>();
    }
}
