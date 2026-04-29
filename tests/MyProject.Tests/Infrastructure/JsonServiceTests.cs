using Xunit;
using MyProject.Infrastructure.Serialization;

namespace MyProject.Tests.Infrastructure;

public class JsonServiceTests
{
    [Fact]
    public void Should_Serialize_And_Deserialize_Object()
    {
        var service = new JsonService();

        var obj = new TestDto { Name = "BMW", Value = 10 };

        var json = service.Serialize(obj);
        var result = service.Deserialize<TestDto>(json);

        Assert.NotNull(result);
        Assert.Equal("BMW", result.Name);
        Assert.Equal(10, result.Value);
    }

    private class TestDto
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}