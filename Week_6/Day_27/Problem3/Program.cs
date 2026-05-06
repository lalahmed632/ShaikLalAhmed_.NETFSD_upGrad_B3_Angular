using System;

abstract class Shape
{
    public abstract double CalculateArea();
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Program
{
    static void Main()
    {
        Shape rect = new Rectangle { Width = 5, Height = 4 };
        Shape circle = new Circle { Radius = 3 };

        Console.WriteLine("Rectangle Area: " + rect.CalculateArea());
        Console.WriteLine("Circle Area: " + circle.CalculateArea());
    }
}