using System;
using System.Collections.Generic;

class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int Marks { get; set; }
}

class StudentRepository
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public List<Student> GetStudents()
    {
        return students;
    }
}

class ReportGenerator
{
    public void GenerateReport(List<Student> students)
    {
        foreach (var s in students)
        {
            Console.WriteLine($"{s.StudentName} - {s.Marks}");
        }
    }
}

class Program
{
    static void Main()
    {
        var repo = new StudentRepository();
        repo.AddStudent(new Student { StudentId = 1, StudentName = "Lal", Marks = 85 });

        var report = new ReportGenerator();
        report.GenerateReport(repo.GetStudents());

        Console.ReadLine();
    }
}