using System;
using System.Text;

namespace _15.DrawingTool
{
    public class Rectangle
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public Rectangle()
        {
        }

        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public void Draw()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < this.height; i++)
            {
                if (i == 0 || i == this.Height - 1)
                {
                    sb.AppendLine($"|{new string('-', this.Width)}|");
                }
                else
                {
                    sb.AppendLine($"|{new string(' ', this.Width)}|");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
