using System;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Sales Amount: ");
            decimal sales = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Rating (1-5): ");
            int rating = Convert.ToInt32(Console.ReadLine());

            var result = GetPerformance(sales, rating);

            Console.WriteLine("\n--- Employee Details ---");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Sales: {result.sales}");
            Console.WriteLine($"Rating: {result.rating}");
            Console.WriteLine($"Performance: {result.performance}");
        }

        static (decimal sales, int rating, string performance) GetPerformance(decimal sales, int rating)
        {
            string performance = (sales, rating) switch
            {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };

            return (sales, rating, performance);
        }
    }
}

