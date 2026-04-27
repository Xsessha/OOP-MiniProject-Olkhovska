using System.Text.Json;
using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;

namespace MyProject.Infrastructure.Repositories;

public class JsonCarRepository : ICarRepository
{
    private readonly string _file = "cars.json";

    public void Add(Car car)
    {
        var cars = GetAll();
        cars.Add(car);
        SaveAll(cars);
    }

    public Car? GetById(Guid id)
    {
        return GetAll().FirstOrDefault(c => c.Id == id);
    }

    public List<Car> GetAll()
    {
        if (!File.Exists(_file))
            return new List<Car>();

        var json = File.ReadAllText(_file);
        return JsonSerializer.Deserialize<List<Car>>(json) ?? new List<Car>();
    }

    public void SaveAll(List<Car> cars)
    {
        var json = JsonSerializer.Serialize(cars);
        File.WriteAllText(_file, json);
    }
}