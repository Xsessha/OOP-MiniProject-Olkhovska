using MyProject.Application.Services;
using MyProject.Domain.Entities;
using MyProject.Infrastructure.Repositories;
using MyProject.Console.Menu;
using MyProject.Presentation.Console.Handlers;


var carRepo = new InMemoryCarRepository();
var rentalRepo = new InMemoryRentalRepository();

var service = new RentalService(carRepo, rentalRepo);

var cars = new List<Car>
{
    new Car("BMW X5"),
    new Car("Audi A6"),
    new Car("Toyota Camry"),
    new Car("Mercedes-Benz S-Class"),
    new Car("Tesla Model 3"),
    new Car("Honda Civic"),
    new Car("Ford Mustang"),
    new Car("Volkswagen Golf"),
    new Car("Porsche 911"),
    new Car("Nissan Rogue"),
    new Car("Hyundai Tucson"),
    new Car("Kia Sportage"),
    new Car("Volvo XC90"),
    new Car("Mazda CX-5"),
    new Car("Subaru Outback"),
    new Car("Lexus RX 350"),
    new Car("Chevrolet Camaro"),
    new Car("Jaguar F-Type")
};

foreach (var car in cars)
    carRepo.Add(car);

var rentHandler = new RentCarHandler(service, carRepo);
var returnHandler = new ReturnCarHandler(service);
var availableHandler = new AvailableCarsHandler(carRepo);

var menu = new MenuHandler();

menu.Register(1, "Rent car", rentHandler.Handle);
menu.Register(2, "Return car", returnHandler.Handle);
menu.Register(3, "Show available cars", availableHandler.Handle);

menu.Run();