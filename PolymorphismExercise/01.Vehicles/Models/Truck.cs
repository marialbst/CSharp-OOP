using _01.Vehicles.Utilities;

namespace _01.Vehicles.Models
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
            Validator.IsPositiveNum(quantity);
            this.FuelQuantity += 0.95 * quantity;
        }
    }
}
