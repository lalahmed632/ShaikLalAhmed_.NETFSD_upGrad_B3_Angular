using System;

namespace Problem2
{
    class SimpleCalculator
    {

        public int add(int x, int y)
        {
            return x + y;
        }
        public int subtract(int x, int y)
        {
            return x-y;
        }
        static void Main(string[] args)
        {
            SimpleCalculator sc = new SimpleCalculator();
            Console.WriteLine("The Output is: ");
            Console.WriteLine("Addition: "+sc.add(10, 5));
            Console.WriteLine("Subtraction: "+sc.subtract(10, 5));
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            int num1, num2;
            Console.WriteLine("Enter First Number: ");
            if(!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Invalid Number, Enter a Valid Number");
            }
            Console.WriteLine("Enter Second Number: ");
            while(!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Invalid Number, Enter a Valid Number");
            }

            Console.WriteLine("The Output is: ");
            Console.WriteLine("Addition: " + sc.add(num1, num2));
            Console.WriteLine("Subtraction: " + sc.subtract(num1, num2));


            Console.ReadLine();
        }
    }
}