using System;
using System.Threading.Tasks;

namespace ConsoleApp2
{
     class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Starting report generation...");

            Task t1 = Task.Run(() => GenerateSalesReport());
            Task t2 = Task.Run(() => GenerateInventoryReport());
            Task t3 = Task.Run(() => GenerateCustomerReport());

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("All reports generated!");
        }

        static void GenerateSalesReport()
        {
            Console.WriteLine("Sales Report Started");
            await Task.Delay(2000);
            Console.WriteLine("Sales Report Completed");
        }

        static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started");
            await Task.Delay(2000);
            Console.WriteLine("Inventory Report Completed");
        }

        static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started");
            await Task.Delay(2000);
            Console.WriteLine("Customer Report Completed");
        }
    }
}

