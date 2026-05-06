using System;

namespace EmployeeSalaryCalculator
{
    class Employee
    {
        public String Name {  get; set; }
        public double BaseSalary {  get; set; }

        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }
    class Manager : Employee
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }
    class Developer: Employee 
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }
    class Result
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Manager();
            employee1.BaseSalary = 50000;

            Employee employee2 = new Developer();
            employee2.BaseSalary = 50000;

            Console.WriteLine($"Manager Salary {employee1.CalculateSalary()}");
            Console.WriteLine($"Developer Salary  {employee2.CalculateSalary()}");

            Console.ReadLine();
        }
    }
}