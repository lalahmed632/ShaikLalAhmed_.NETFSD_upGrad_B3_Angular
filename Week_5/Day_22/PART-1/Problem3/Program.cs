using System;

class Program
{
    static void Divide(int numerator, int denominator)
    {
        try
        {
            int result = numerator / denominator;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero");
        }
        finally
        {
            Console.WriteLine("Operation completed safely");
        }
    }

    static void Main()
    {
        Console.Write("Enter Numerator: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Denominator: ");
        int den = Convert.ToInt32(Console.ReadLine());

        Divide(num, den);

        Console.ReadLine();
    }
}