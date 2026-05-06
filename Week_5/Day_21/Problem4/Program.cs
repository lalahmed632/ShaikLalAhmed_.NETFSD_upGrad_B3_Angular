using System;

namespace VehicleRentalSystem
{
    class Vehicle
    {
        private double _rentalRatePerDay;

        public string Brand { get; set; }

        public double RentalRatePerDay
        {
            get { return _rentalRatePerDay; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Invalid Rental Rate");
                    return;
                }

                _rentalRatePerDay = value;
            }
        }

        public virtual double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid rental days");
                return 0;
            }

            return RentalRatePerDay * days;
        }
    }

    class Car : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double baseCost = base.CalculateRental(days);
            return baseCost + 500;
        }
    }

    class Bike : Vehicle
    {
        public override double CalculateRental(int days)
        {
            double baseCost = base.CalculateRental(days);
            return baseCost - (baseCost * 0.05);
        }
    }

    class Result
    {
        static void Main(string[] args)
        {
            Vehicle car = new Car();
            car.Brand = "Toyota";
            car.RentalRatePerDay = 2000;

            double total = car.CalculateRental(3);

            Console.WriteLine("Total Rental = " + total);

            Console.ReadLine();
        }
    }
}