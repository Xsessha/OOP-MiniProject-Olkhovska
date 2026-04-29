using Xunit;
using MyProject.Infrastructure.Repositories;
using MyProject.Domain.Entities;

namespace MyProject.Tests.Infrastructure;

public class InMemoryCarRepositoryTests
{
    [Fact]
    public void Should_Filter_Available_Cars()
    {
        var repo = new InMemoryCarRepository();

        var car = new Car("BMW");
        repo.Add(car);

        var available = repo.GetAvailable();

        Assert.NotNull(available);
    }

    [Fact]
    public void Should_Find_By_Model()
    {
        var repo = new InMemoryCarRepository();

        repo.Add(new Car("BMW"));

        var result = repo.FindByModel("BMW");

        Assert.NotNull(result);
    }
}