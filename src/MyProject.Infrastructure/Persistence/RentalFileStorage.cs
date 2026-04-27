using System.Text.Json;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Persistence;

public class RentalFileStorage
{
    private const string FilePath = "rentals.json";

    public void SaveRentals(List<Rental> rentals)
    {
        var json = JsonSerializer.Serialize(rentals, new JsonSerializerOptions
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

        return JsonSerializer.Deserialize<List<Rental>>(json) ?? new List<Rental>();
    }
}