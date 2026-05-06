using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        // Configure Trace to write into a file
        Trace.Listeners.Clear();

        TextWriterTraceListener writer = new TextWriterTraceListener("log.txt");
        Trace.Listeners.Add(writer);

        Trace.AutoFlush = true;

        Console.WriteLine("Order Processing Started...\n");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order processed successfully.");
        }
        catch (Exception ex)
        {
            Trace.WriteLine($"ERROR: {ex.Message}");
        }

        Console.WriteLine("Processing Completed. Check log.txt file.");
    }

    static void ValidateOrder()
    {
        Trace.WriteLine("Step 1: Validating Order...");
        Console.WriteLine("Validating Order...");
    }

    static void ProcessPayment()
    {
        Trace.WriteLine("Step 2: Processing Payment...");
        Console.WriteLine("Processing Payment...");

        // Simulate failure (for debugging demo)
        // Uncomment to test failure
        // throw new Exception("Payment Failed!");
    }

    static void UpdateInventory()
    {
        Trace.WriteLine("Step 3: Updating Inventory...");
        Console.WriteLine("Updating Inventory...");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Step 4: Generating Invoice...");
        Console.WriteLine("Generating Invoice...");
    }
}