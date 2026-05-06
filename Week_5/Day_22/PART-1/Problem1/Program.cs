using System;
using System.Collections.Generic;

public record Student(int RollNumber, string Name, string Course, int Marks);

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("~~~~~~~~~ Student Record Management ~~~~~~~~~~~~~");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DisplayStudents();
                    break;
                case 3:
                    SearchStudent();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (choice != 4);
    }

    static void AddStudent()
    {
        int roll, marks;
        string name, course;

        Console.Write("Enter Roll Number: ");
        while (!int.TryParse(Console.ReadLine(), out roll) || roll <= 0)
        {
            Console.Write("Invalid Roll Number. Enter again: ");
        }

        Console.Write("Enter Name: ");
        name = Console.ReadLine();

        Console.Write("Enter Course: ");
        course = Console.ReadLine();

        Console.Write("Enter Marks (0-100): ");
        while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
        {
            Console.Write("Invalid Marks. Enter between 0 and 100: ");
        }

        Student s = new Student(roll, name, course, marks);

        students.Add(s);
        Console.WriteLine("Student added successfully.");
    }

    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        Console.WriteLine("\n--- Student Records ---");
        foreach (var s in students)
        {
            Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Roll Number to search: ");

        if (!int.TryParse(Console.ReadLine(), out int roll))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        foreach (var s in students)
        {
            if (s.RollNumber == roll)
            {
                Console.WriteLine("\nStudent Found:");
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                return;
            }
        }

        Console.WriteLine("Record not found.");
    }
}