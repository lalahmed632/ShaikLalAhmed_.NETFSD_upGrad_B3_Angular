using System;

namespace CaseStudy
{
    class Employee
    {
        private string _fullName;
        private int _age;
        private decimal _salary;
        private int _employeeId;

        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                _fullName = value.Trim();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 18 || value > 80)
                {
                    throw new ArgumentException("Age must be between 18 and 80");
                }

                _age = value;
            }
        }

        public decimal Salary
        {
            get => _salary;
            private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("Salary must be at least 1000");
                }

                _salary = value;
            }
        }

        public int EmployeeId
        {
            get => _employeeId;
        }

        public Employee(string name, decimal sal, int a, int id)
        {
            FullName = name;
            Salary = sal;
            Age = a;
            _employeeId = id;
        }

        public void GiveRaise(decimal percent)
        {
            if (percent <= 0 || percent > 30)
            {
                throw new ArgumentException("Raise must be between 0 and 30 percent");
            }

            decimal increase = Salary * percent / 100;
            Salary = Salary + increase;
        }

        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (Salary - amount < 1000)
            {
                return false;
            }

            Salary = Salary - amount;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("sharan", 3000, 25, 101);

            Console.WriteLine($"Employee ID: {emp.EmployeeId}");
            Console.WriteLine($"Name: {emp.FullName}");
            Console.WriteLine($"Age: {emp.Age}");
            Console.WriteLine($"Salary: {emp.Salary}");

            emp.GiveRaise(10);

            Console.WriteLine("Salary after raise: " + emp.Salary);

            bool result = emp.DeductPenalty(500);

            if (result)
            {
                Console.WriteLine("Penalty applied. Salary now: " + emp.Salary);
            }
            else
            {
                Console.WriteLine("Penalty not allowed.");
            }

            Console.ReadLine();
        }
    }
}