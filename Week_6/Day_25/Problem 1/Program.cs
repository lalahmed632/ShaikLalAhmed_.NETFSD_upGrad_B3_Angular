using System;
using System.Threading.Tasks;

namespace ConsoleApp2
{
     class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Application Started");

            // Calling async logger multiple times
            Task t1 = WriteLogAsync("User logged in");
            Task t2 = WriteLogAsync("File uploaded");
            Task t3 = WriteLogAsync("Order placed");

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("All logs written");
        }

        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start writing log: {message}");

            await Task.Delay(3000); // simulate file writing

            Console.WriteLine($"Finished writing log: {message}");
        }
    }
}

