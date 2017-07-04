namespace _09.RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double xCoord;
        private double yCoord;

        public Rectangle(string id, double width, double height, double xCoord, double yCoord)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
        }

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public double XCoord
        {
            get { return this.xCoord; }
            set { this.xCoord = value; }
        }

        public double YCoord
        {
            get { return this.yCoord; }
            set { this.yCoord = value; }
        }

        public bool IsIntersect(Rectangle rect)
        {
            return (this.XCoord + this.Width >= rect.XCoord && this.YCoord + this.Height >= rect.YCoord) && (rect.XCoord + rect.Width >= this.XCoord && rect.YCoord + rect.Height >= this.YCoord);
        }
    }
}
