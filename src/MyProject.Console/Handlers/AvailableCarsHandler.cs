namespace MyProject.Presentation.Console.Handlers;

using MyProject.Domain.Interfaces;

public class AvailableCarsHandler
{
    private readonly ICarRepository _carRepository;

    public AvailableCarsHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public void Handle()
    {
        System.Console.WriteLine("\nAVAILABLE CARS");

        var cars = _carRepository.GetAll();

        foreach (var car in cars)
        {
            System.Console.WriteLine($"{car.Id} | {car.Model}");
        }
    }
}