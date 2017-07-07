using System;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    private double Radius
    {
        get { return this.radius; }
        set { this.radius = value; }
    }

    public override double CalculatePerimeter()
    {
        return Math.PI * 2 * radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public override string Draw()
    {
        return base.Draw() + $"{this.GetType().Name}";
    }
}
