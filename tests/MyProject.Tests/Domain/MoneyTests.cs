using Xunit;
using MyProject.Domain.ValueObjects;

namespace MyProject.Tests.Domain;

public class MoneyComparisonTests
{
    [Fact]
    public void Should_Compare_Money_Greater_And_Less()
    {
        var a = new Money(20);
        var b = new Money(10);

        Assert.True(a > b);
        Assert.True(b < a);
    }
}