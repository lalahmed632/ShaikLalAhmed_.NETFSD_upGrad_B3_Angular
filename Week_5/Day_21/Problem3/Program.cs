using System;

namespace OnlineShoppingCartSystem
{
    class Product
    {
        private double _price;

        public string Name { get; set; }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Price cannot be negative");
                    return;
                }

                _price = value;
            }
        }

        public virtual double CalculateDiscount()
        {
            return Price;
        }
    }

    class Electronics : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.05);
        }
    }

    class Clothing : Product
    {
        public override double CalculateDiscount()
        {
            return Price - (Price * 0.15);
        }
    }

    class Result
    {
        static void Main(string[] args)
        {
            Product electronics = new Electronics();
            electronics.Name = "Laptop";
            electronics.Price = 20000;

            double finalPrice = electronics.CalculateDiscount();

            Console.WriteLine($"Final Price after 5% discount = {finalPrice}");

            Console.ReadLine();
        }
    }
}