namespace MyProject.Domain.Entities;

public abstract class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }

    protected Customer(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty");

        Name = name;
    }

    public abstract decimal GetDiscount();

    public override bool Equals(object? obj)
    {
        if (obj is not Customer other)
            return false;

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}