using Xunit;
using MyProject.Infrastructure.Persistence;
using MyProject.Domain.Entities;
using System.IO;
using System.Collections.Generic;

namespace MyProject.Tests.Infrastructure;

public class RentalFileStorageTests
{
    private const string FilePath = "rentals.json";

    [Fact]
    public void Should_Save_And_Load_Rentals()
    {
        // cleanup
        if (File.Exists(FilePath))
            File.Delete(FilePath);

        var storage = new RentalFileStorage();

        var rentals = new List<Rental>
        {
            new Rental(new Car("BMW"), new EconomyCustomer("User"))
        };

        // ACT
        storage.SaveRentals(rentals);
        var loaded = storage.LoadRentals();

        // ASSERT
        Assert.NotNull(loaded);
        Assert.Single(loaded);

        Assert.Equal("BMW", loaded[0].Car.Model);
        Assert.Equal("User", loaded[0].Customer.Name);
    }

    [Fact]
    public void Should_Return_Empty_List_If_File_Not_Exists()
    {
        if (File.Exists(FilePath))
            File.Delete(FilePath);

        var storage = new RentalFileStorage();

        var result = storage.LoadRentals();

        Assert.NotNull(result);
        Assert.Empty(result);
    }
}