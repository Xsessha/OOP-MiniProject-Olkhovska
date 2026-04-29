namespace MyProject.Domain.Entities;

public class Rental
{
    public Guid Id { get; }
    public Car Car { get; }
    public Customer Customer { get; }
    public DateTime Date { get; }

    public Rental(Car car, Customer customer)
    {
        if (car == null)
            throw new ArgumentNullException(nameof(car));

        if (customer == null)
            throw new ArgumentNullException(nameof(customer));

        if (!car.IsAvailable)
            throw new InvalidOperationException("Car is already rented");

        Id = Guid.NewGuid();
        Car = car;
        Customer = customer;
        Date = DateTime.Now;

        car.Rent();
    }
}
