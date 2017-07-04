namespace _07.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double traveledDistance;
        
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.model = model;
            this.fuelConsumption = fuelConsumption;
            this.fuelAmount = fuelAmount;
        }
        
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double TraveledDistance
        {
            get { return this.traveledDistance; }
            set { this.traveledDistance = value; }
        }

        public bool IsFuelEnough(double distance)
        {
            return this.fuelConsumption * distance <= this.fuelAmount;
        }

        public void CalculateFuel(double distance)
        {
            this.fuelAmount -= this.fuelConsumption * distance;
            this.traveledDistance += distance;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TraveledDistance}";
        }
    }
}
