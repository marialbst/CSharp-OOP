using _01.Vehicles.Utilities;

namespace _01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double IncreaseVal = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.Increase = IncreaseVal;
        }

        public override double Increase { get; set;}

        public override void Refuel(double quantity)
        {
            base.Refuel(quantity);
            Validator.IsCapacityEnough(quantity, this.TankCapacity, this.FuelQuantity);
            this.FuelQuantity += quantity;
        }
    }
}
