using System;

namespace Problem3
{
    class Student
    {
        public int Calculate(int m1, int m2, int m3)
        {
            return (m1 + m2 + m3)/3;
        }
        static void Main(String[] args)
        {
            Student s = new Student();

            int num1,num2,num3;

            Console.WriteLine("Enter First Number");
            while(!int.TryParse(Console.ReadLine(), out num1) || num1 <= 0 || num1 >= 100)
            {
                Console.WriteLine("Invalid First Number,Enter Valid Number ");
            }


            Console.WriteLine("Enter Second Number");
            while (!int.TryParse(Console.ReadLine(), out num2) || num1 <= 0 || num1 >= 100)
            {
                Console.WriteLine("Invalid Second Number,Enter Valid Number ");
            }

            Console.WriteLine("Enter Third Number");
            while (!int.TryParse(Console.ReadLine(), out num3) || num1 <= 0 || num1 >= 100)
            {
                Console.WriteLine("Invalid Third Number,Enter Valid Number ");
            }

            int avg = s.Calculate(num1, num2, num3);

            if (avg <= 0 || avg >= 100)
            {
                Console.WriteLine("Enter Valid Numbers to get the Average and Grade");
                Console.ReadLine();
                return;
            }

            if (avg >= 80)
            {
                Console.WriteLine("Average :" + avg);
                Console.WriteLine("Grade A");
            }
            else if (avg>=60)
            {
                Console.WriteLine("Average :" + avg);
                Console.WriteLine("Grade B");
            }
            else if (avg >= 50)
            {
                Console.WriteLine("Average :" + avg);
                Console.WriteLine("Grade C");
            }
            else if (avg >= 40)
            {
                Console.WriteLine("Average :" + avg);
                Console.WriteLine("Grade D");
            }
            else
            {
                Console.WriteLine("Average :" + avg);
                Console.WriteLine("Fail");
            }
            Console.ReadLine();
        }
    }
}