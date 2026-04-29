using MyProject.Domain.Entities;
using Xunit;

public class CustomerTests
{
    [Fact]
    public void ShouldThrowIfNameEmpty()
    {
        Assert.Throws<ArgumentException>(() => new EconomyCustomer(""));
    }

    [Fact]
    public void PremiumCustomerShouldHaveHigherDiscount()
    {
        var premium = new PremiumCustomer("Alex");
        var economy = new EconomyCustomer("Bob");

        Assert.True(premium.GetDiscount() > economy.GetDiscount());
    }

    [Fact]
    public void DiscountsShouldBePositive()
    {
        var premium = new PremiumCustomer("Alex");

        Assert.True(premium.GetDiscount() > 0);
    }


    [Fact]
    public void ShouldThrowIfNameNull()
    {
        Assert.Throws<ArgumentException>(() => new EconomyCustomer(null!));
    }

    [Fact]
    public void Premium_ShouldThrowIfNameEmpty()
    {
        Assert.Throws<ArgumentException>(() => new PremiumCustomer(""));
    }

    [Fact]
    public void Premium_ShouldThrowIfNameNull()
    {
        Assert.Throws<ArgumentException>(() => new PremiumCustomer(null!));
    }

    [Fact]
    public void Discount_ShouldNotBeNegative_ForEconomy()
    {
        var customer = new EconomyCustomer("Test");

        Assert.True(customer.GetDiscount() >= 0);
    }

    [Fact]
    public void Discount_ShouldNotBeNegative_ForPremium()
    {
        var customer = new PremiumCustomer("Test");

        Assert.True(customer.GetDiscount() >= 0);
    }


    [Fact]
    public void PremiumCustomer_ShouldReturnStableDiscount()
    {
        var customer = new PremiumCustomer("Alex");

        var d1 = customer.GetDiscount();
        var d2 = customer.GetDiscount();

        Assert.Equal(d1, d2);
    }

    [Fact]
    public void EconomyCustomer_ShouldReturnStableDiscount()
    {
        var customer = new EconomyCustomer("Bob");

        var d1 = customer.GetDiscount();
        var d2 = customer.GetDiscount();

        Assert.Equal(d1, d2);
    }

    [Fact]
    public void Customers_WithSameType_ShouldHaveSameDiscount()
    {
        var c1 = new EconomyCustomer("A");
        var c2 = new EconomyCustomer("B");

        Assert.Equal(c1.GetDiscount(), c2.GetDiscount());
    }


    [Fact]
    public void Customer_NameShouldBeStored()
    {
        var customer = new EconomyCustomer("John");

        Assert.Equal("John", customer.Name);
    }

    [Fact]
    public void DifferentCustomers_ShouldNotAffectEachOther()
    {
        var c1 = new PremiumCustomer("Alex");
        var c2 = new EconomyCustomer("Bob");

        Assert.NotEqual(c1.GetDiscount(), c2.GetDiscount());
    }

    [Fact]
    public void Customer_IdShouldBeUnique()
    {
        var c1 = new EconomyCustomer("A");
        var c2 = new EconomyCustomer("B");

        Assert.NotEqual(c1.Id, c2.Id);
    }

    [Fact]
    public void Customer_StateShouldRemainStable()
    {
        var customer = new PremiumCustomer("Alex");

        var discountBefore = customer.GetDiscount();

        for (int i = 0; i < 5; i++)
        {
            customer.GetDiscount();
        }

        var discountAfter = customer.GetDiscount();

        Assert.Equal(discountBefore, discountAfter);
    }
}