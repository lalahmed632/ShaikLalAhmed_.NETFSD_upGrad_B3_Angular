using System;

interface IDiscountStrategy
{
    double CalculateDiscount(double amount);
}

class RegularCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.05;
}

class PremiumCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.10;
}

class VipCustomerDiscount : IDiscountStrategy
{
    public double CalculateDiscount(double amount) => amount * 0.20;
}

class Program
{
    static void Main()
    {
        IDiscountStrategy discount = new VipCustomerDiscount();
        double amount = 1000;

        double finalPrice = amount - discount.CalculateDiscount(amount);
        Console.WriteLine("Final Price: " + finalPrice);
    }
}