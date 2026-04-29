using MyProject.Application.Services;
using MyProject.Domain.Entities;
using MyProject.Infrastructure.Repositories;

namespace MyProject.Tests.Helpers;

public static class FakeData
{
    public static RentalService CreateService(out InMemoryCarRepository carRepo)
    {
        carRepo = new InMemoryCarRepository();
        var rentalRepo = new InMemoryRentalRepository();

        return new RentalService(carRepo, rentalRepo);
    }

    public static Car CreateCar(string model = "BMW")
    {
        return new Car(model);
    }

    public static List<Car> CreateCars()
    {
        return new List<Car>
        {
            new Car("BMW"),
            new Car("Audi"),
            new Car("Tesla")
        };
    }
}