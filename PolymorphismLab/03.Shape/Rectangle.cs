public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    private double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    private double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public override double CalculatePerimeter()
    {
        return 2 * (this.Width + this.Height);
    }

    public override double CalculateArea()
    {
        return this.Width * this.Height;
    }

    public override string Draw()
    {
        return base.Draw() + $"{this.GetType().Name}";
    }
}
