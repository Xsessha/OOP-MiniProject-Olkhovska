using MyProject.Application.Factories;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using System.Linq;

namespace MyProject.Application.Services;

public class RentalService
{
    private readonly ICarRepository _carRepository;
    private readonly IRentalRepository _rentalRepository;

    public RentalService(ICarRepository carRepository, IRentalRepository rentalRepository)
    {
        _carRepository = carRepository;
        _rentalRepository = rentalRepository;
    }

    public Result RentCar(string customerName, Guid carId)
    {
        var car = _carRepository.GetById(carId);

        if (car == null)
            return Result.Fail("Car not found");

        if (!car.IsAvailable)
            return Result.Fail("Car already rented");

        var customer = CustomerFactory.Create(customerName, "economy");

        car.Rent();

        var rental = new Rental(car, customer);

        _rentalRepository.Add(rental);

        return Result.Ok();
    }

    public Result ReturnCar(Guid carId)
    {
        var car = _carRepository.GetById(carId);

        if (car == null)
            return Result.Fail("Car not found");

        var rental = _rentalRepository.GetAll()
            .FirstOrDefault(r => r.Car.Id == carId);

        if (rental == null)
            return Result.Fail("Rental not found");

        car.Return();

        return Result.Ok();
    }

    public List<Car> GetAvailableCars()
    {
        return _carRepository.GetAll()
            .Where(c => c.IsAvailable)
            .OrderBy(c => c.Model)
            .ToList();
    }
}