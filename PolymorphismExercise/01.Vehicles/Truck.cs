namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double IncreaseVal = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.Increase = IncreaseVal;
        }

        public override void Refuel(double quantity)
        {
            this.FuelQuantity += 0.95 * quantity;
        }

        public override double Increase { get; set; }
    }
}
