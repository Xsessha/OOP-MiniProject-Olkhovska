using Xunit;
using MyProject.Domain.Exceptions;

namespace MyProject.Tests.Domain;

public class DomainExceptionTests
{
    [Fact]
    public void Should_Throw_DomainException()
    {
        void act() => throw new DomainException("Error");

        Assert.Throws<DomainException>(act);
    }
}