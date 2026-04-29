using System.Text.Json;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Persistence;

public class RentalFileStorage
{
    private const string FilePath = "rentals.json";

    public void SaveRentals(List<Rental> rentals)
    {
        var dtos = rentals.Select(r => new RentalDto
        {
            CarModel = r.Car.Model,
            CustomerName = r.Customer.Name,
            CustomerType = r.Customer.GetType().Name
        }).ToList();

        var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FilePath, json);
    }

    public List<Rental> LoadRentals()
    {
        if (!File.Exists(FilePath))
            return new List<Rental>();

        var json = File.ReadAllText(FilePath);

        var dtos = JsonSerializer.Deserialize<List<RentalDto>>(json) ?? new List<RentalDto>();

        return dtos.Select(dto =>
        {
            Customer customer = dto.CustomerType switch
            {
                nameof(EconomyCustomer) => new EconomyCustomer(dto.CustomerName),
                nameof(PremiumCustomer) => new PremiumCustomer(dto.CustomerName),
                _ => throw new Exception($"Unknown customer type: {dto.CustomerType}")
            };

            var car = new Car(dto.CarModel);

            return new Rental(car, customer);
        }).ToList();
    }
}