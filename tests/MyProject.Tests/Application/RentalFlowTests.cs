using MyProject.Domain.Entities;
using Xunit;

public class RentalTests
{
    [Fact]
    public void ShouldCreateRental()
    {
        var car = new Car("BMW");
        var customer = new EconomyCustomer("John");

        var rental = new Rental(car, customer);

        Assert.NotNull(rental);
    }

    [Fact]
    public void ShouldThrowIfCarNull()
    {
        var customer = new EconomyCustomer("John");

        Assert.Throws<ArgumentNullException>(() =>
            new Rental(null!, customer));
    }

    [Fact]
    public void ShouldThrowIfCustomerNull()
    {
        var car = new Car("BMW");

        Assert.Throws<ArgumentNullException>(() =>
            new Rental(car, null!));
    }

    // Lab 36


    [Fact]
    public void Rental_ShouldStoreCarReference()
    {
        var car = new Car("Audi");
        var customer = new EconomyCustomer("John");

        var rental = new Rental(car, customer);

        Assert.Equal(car, rental.Car);
    }

    [Fact]
    public void Rental_ShouldStoreCustomerReference()
    {
        var car = new Car("Audi");
        var customer = new EconomyCustomer("John");

        var rental = new Rental(car, customer);

        Assert.Equal(customer, rental.Customer);
    }

    [Fact]
    public void Rental_CarShouldNotBeAvailableAfterCreation()
    {
        var car = new Car("BMW");
        var customer = new EconomyCustomer("John");

        var rental = new Rental(car, customer);

        Assert.False(car.IsAvailable);
    }

    [Fact]
    public void Rental_MultipleRentalsSameCar_ShouldBePrevented()
    {
        var car = new Car("BMW");
        var customer1 = new EconomyCustomer("John");
        var customer2 = new EconomyCustomer("Anna");

        var rental1 = new Rental(car, customer1);

        Assert.False(car.IsAvailable);

        Assert.ThrowsAny<Exception>(() =>
            new Rental(car, customer2));
    }

    [Fact]
    public void Rental_ShouldHaveValidId()
    {
        var car = new Car("BMW");
        var customer = new EconomyCustomer("John");

        var rental = new Rental(car, customer);

        Assert.NotEqual(Guid.Empty, rental.Id);
    }

    [Fact]
    public void Rental_ShouldNotCrashOnMultipleCreatesDifferentCars()
    {
        var car1 = new Car("BMW");
        var car2 = new Car("Audi");

        var customer = new EconomyCustomer("John");

        var r1 = new Rental(car1, customer);
        var r2 = new Rental(car2, customer);

        Assert.NotEqual(r1.Id, r2.Id);
    }
}