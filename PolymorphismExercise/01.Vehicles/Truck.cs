namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
            :base(fuelQuantity, fuelConsumption + 1.6)
        {
        }

        public override void Refuel(double quantity)
        {
            this.FuelQuantity += 0.95 * quantity;
        }
    }
}
