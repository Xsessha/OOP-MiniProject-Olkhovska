using MyProject.Application.Services;
using MyProject.Domain.Entities;
using MyProject.Infrastructure.Repositories;
using Xunit;

namespace MyProject.Tests.Domain;

public class RentalServiceTests
{
    [Fact]
    public void ShouldRentCar()
    {
        var carRepo = new InMemoryCarRepository();
        var rentalRepo = new InMemoryRentalRepository();
        var service = new RentalService(carRepo, rentalRepo);

        var car = new Car("BMW");
        carRepo.Add(car);

        var result = service.RentCar("User", car.Id);

        Assert.True(result.Success);
        Assert.False(car.IsAvailable);
    }

    [Fact]
    public void ShouldThrowIfCarAlreadyRented()
    {
        var carRepo = new InMemoryCarRepository();
        var rentalRepo = new InMemoryRentalRepository();
        var service = new RentalService(carRepo, rentalRepo);

        var car = new Car("BMW");
        carRepo.Add(car);

        service.RentCar("User", car.Id);

        var result = service.RentCar("User", car.Id);

        Assert.False(result.Success);
    }

    [Fact]
    public void ShouldHandleMultipleCars()
    {
        var carRepo = new InMemoryCarRepository();
        var rentalRepo = new InMemoryRentalRepository();
        var service = new RentalService(carRepo, rentalRepo);

        var car1 = new Car("BMW");
        var car2 = new Car("Audi");

        carRepo.Add(car1);
        carRepo.Add(car2);

        service.RentCar("User", car1.Id);

        Assert.False(car1.IsAvailable);
        Assert.True(car2.IsAvailable);
    }

    [Fact]
    public void FullFlow_ShouldWork()
    {
        var carRepo = new InMemoryCarRepository();
        var rentalRepo = new InMemoryRentalRepository();
        var service = new RentalService(carRepo, rentalRepo);

        var car = new Car("BMW");
        carRepo.Add(car);

        var rent = service.RentCar("User", car.Id);
        var ret = service.ReturnCar(car.Id);

        Assert.True(rent.Success);
        Assert.True(ret.Success);
    }
}