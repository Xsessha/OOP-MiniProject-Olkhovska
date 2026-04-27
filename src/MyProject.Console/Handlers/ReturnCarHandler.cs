namespace MyProject.Presentation.Console.Handlers;

using MyProject.Application.Services;

public class ReturnCarHandler
{
    private readonly RentalService _service;

    public ReturnCarHandler(RentalService service)
    {
        _service = service;
    }

    public void Handle()
    {
        System.Console.WriteLine("\nRETURN CAR");

        System.Console.Write("Enter car ID: ");
        var input = System.Console.ReadLine();

        if (!Guid.TryParse(input, out var carId))
        {
            System.Console.WriteLine("Invalid ID format");
            return;
        }

        var result = _service.ReturnCar(carId);

        if (result.Success)
            System.Console.WriteLine("Car returned successfully!");
        else
            System.Console.WriteLine(result.Error);
    }
}