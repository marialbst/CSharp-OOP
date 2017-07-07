public abstract class Shape
{
    public abstract double CalculatePerimeter();

    public abstract double CalculateArea();

    public virtual string Draw()
    {
        return "Drawing ";
    }

    public override string ToString()
    {
        return $"{this.Draw()} - Perimeter: {this.CalculatePerimeter():f2}, Area: {this.CalculateArea():f2}";
    }
}
