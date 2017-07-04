using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<Rectangle> rectangles = ReadRectangles(tokens[0]);

            for (int i = 0; i < tokens[1]; i++)
            {
                string[] rects = Console.ReadLine().Split();
                var rect1 = rectangles.First(r => r.Id == rects[0]);
                var rect2 = rectangles.First(r => r.Id == rects[1]);

                Console.WriteLine(rect1.IsIntersect(rect2).ToString().ToLower());
            }
        }

        private static List<Rectangle> ReadRectangles(int count)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                var id = input[0];
                var rectangleValues = input.Skip(1).Select(double.Parse).ToArray();

                Rectangle rect = new Rectangle(id, rectangleValues[0], rectangleValues[1], rectangleValues[2], rectangleValues[3]);
                rectangles.Add(rect);
            }

            return rectangles;
        }
    }
}
