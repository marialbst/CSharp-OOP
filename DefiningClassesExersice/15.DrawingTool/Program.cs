using System;

namespace _15.DrawingTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "Square")
            {
                int side = int.Parse(Console.ReadLine());
                Square sq = new Square(side);
                CorDraw draw = new CorDraw(sq);
            }
            else
            {
                int width = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                Rectangle rect = new Rectangle(width, height);
                CorDraw draw = new CorDraw(rect);
            }
        }
    }
}
