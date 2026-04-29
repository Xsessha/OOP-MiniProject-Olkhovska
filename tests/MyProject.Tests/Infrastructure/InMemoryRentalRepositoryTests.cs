using Xunit;
using MyProject.Infrastructure.Repositories;
using MyProject.Domain.Entities;

namespace MyProject.Tests.Infrastructure;

public class InMemoryRentalRepositoryTests
{
    [Fact]
    public void Should_Return_All_Rentals()
    {
        var repo = new InMemoryRentalRepository();

        repo.Add(new Rental(new Car("BMW"), new EconomyCustomer("User")));

        var result = repo.GetAll();

        Assert.NotNull(result);
    }
}