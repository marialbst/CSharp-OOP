using System;

class Program
{
    static void Main(string[] args)
    {
        Shape rect = new Rectangle(5, 5);
        Shape circle = new Circle(4);

        Console.WriteLine(rect);
        Console.WriteLine(circle);
    }
}

