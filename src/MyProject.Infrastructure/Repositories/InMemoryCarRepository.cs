using MyProject.Domain.Entities;
using MyProject.Domain.Interfaces;
using System.Linq;

namespace MyProject.Infrastructure.Repositories;

public class InMemoryCarRepository : ICarRepository
{
    private readonly Dictionary<Guid, Car> _cars = new();

    public void Add(Car car)
    {
        _cars[car.Id] = car;
    }

    public Car? GetById(Guid id)
    {
        return _cars.TryGetValue(id, out var car) ? car : null;
    }

    public List<Car> GetAll()
    {
        return _cars.Values.ToList();
    }


    public List<Car> GetAvailable()
    {
        return _cars.Values
            .Where(c => c.IsAvailable)
            .OrderBy(c => c.Model)
            .ToList();
    }

    public List<Car> GetRented()
    {
        return _cars.Values
            .Where(c => !c.IsAvailable)
            .ToList();
    }

    public Car? FindByModel(string model)
    {
        return _cars.Values
            .FirstOrDefault(c =>
                c.Model.Contains(model, StringComparison.OrdinalIgnoreCase));
    }
}