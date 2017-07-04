namespace _10.CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine, int weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }

        public Car(string model, Engine engine)
            :this(model, engine, -1, "n/a")
        {}

        public Car(string model, Engine engine, int weight)
            : this(model, engine, weight, "n/a")
        { }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1, color)
        { }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public override string ToString()
        {
            var displacement = this.Engine.Displacement != -1 ? this.Engine.Displacement.ToString() : "n/a";
            var weight = this.Weight != -1 ? this.Weight.ToString() : "n/a";

            string result = $"{this.Model}:\n {this.Engine.Model}:\n  Power: {this.Engine.Power}\n  ";
            result += $"Displacement: {displacement}\n  Efficiency: {this.Engine.Efficiency}\n ";
            result += $"Weight: {weight}\n Color: {this.Color}";
            return result;
        }
    }
}
