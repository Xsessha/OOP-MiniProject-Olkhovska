using MyProject.Domain.Entities;
using Xunit;

public class CarTests
{
    [Fact]
    public void ShouldRentCar()
    {
        var car = new Car("BMW");

        car.Rent();

        Assert.False(car.IsAvailable);
    }

    [Fact]
    public void ShouldNotAllowDoubleRent()
    {
        var car = new Car("BMW");

        car.Rent();

        Assert.Throws<InvalidOperationException>(() => car.Rent());
    }

    [Fact]
    public void ShouldBeAvailableAfterCreation()
    {
        var car = new Car("BMW");

        Assert.True(car.IsAvailable);
    }

    [Fact]
    public void ShouldReturnCarEvenIfNotRented()
    {
        var car = new Car("Audi");

        car.Return();

        Assert.True(car.IsAvailable);
    }

    [Fact]
    public void ShouldHaveUniqueId()
    {
        var car1 = new Car("BMW");
        var car2 = new Car("BMW");

        Assert.NotEqual(car1.Id, car2.Id);
    }

    [Fact]
    public void Rent_AlreadyRentedCar_ShouldThrow()
    {
        var car = new Car("BMW");

        car.Rent();

        Assert.Throws<InvalidOperationException>(() => car.Rent());
    }

    [Fact]
    public void Rent_AfterMultipleCalls_ShouldAlwaysFailAfterFirst()
    {
        var car = new Car("BMW");

        car.Rent();

        Assert.Throws<InvalidOperationException>(() => car.Rent());
        Assert.Throws<InvalidOperationException>(() => car.Rent());
    }

    [Fact]
    public void Return_OnNewCar_ShouldNotThrow()
    {
        var car = new Car("BMW");

        var ex = Record.Exception(() => car.Return());

        Assert.Null(ex);
    }

    [Fact]
    public void Return_AfterReturn_ShouldNotCrash()
    {
        var car = new Car("BMW");

        car.Rent();
        car.Return();

        var ex = Record.Exception(() => car.Return());

        Assert.Null(ex);
    }

    [Fact]
    public void Rent_AfterInvalidState_ShouldStillThrow()
    {
        var car = new Car("BMW");

        car.Rent();
        car.Return();
        car.Rent();

        Assert.Throws<InvalidOperationException>(() => car.Rent());
    }

    [Fact]
    public void Rent_ShouldChangeAvailability()
    {
        var car = new Car("BMW");

        car.Rent();

        Assert.False(car.IsAvailable);
    }

    [Fact]
    public void Return_ShouldRestoreAvailability()
    {
        var car = new Car("BMW");

        car.Rent();
        car.Return();

        Assert.True(car.IsAvailable);
    }

    [Fact]
    public void Car_StateFlow_ShouldFollowRentReturnLogic()
    {
        var car = new Car("BMW");

        car.Rent();
        Assert.False(car.IsAvailable);

        car.Return();
        Assert.True(car.IsAvailable);
    }

    // CONSISTENCY 


    [Fact]
    public void MultipleCars_ShouldNotAffectEachOther()
    {
        var car1 = new Car("BMW");
        var car2 = new Car("Audi");

        car1.Rent();

        Assert.False(car1.IsAvailable);
        Assert.True(car2.IsAvailable);
    }

    [Fact]
    public void MultipleRentReturnCycles_ShouldBeStable()
    {
        var car = new Car("BMW");

        for (int i = 0; i < 3; i++)
        {
            car.Rent();
            car.Return();
        }

        Assert.True(car.IsAvailable);
    }

    [Fact]
    public void Car_Id_ShouldRemainConstant()
    {
        var car = new Car("BMW");
        var id = car.Id;

        car.Rent();
        car.Return();

        Assert.Equal(id, car.Id);
    }

    [Fact]
    public void Car_Model_ShouldNotChange()
    {
        var car = new Car("Tesla");

        car.Rent();
        car.Return();

        Assert.Equal("Tesla", car.Model);
    }
}