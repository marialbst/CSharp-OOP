using System;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double IncreaseVal = 0.9;
        
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.Increase = IncreaseVal;
        }

        public override double Increase { get; set; }
    }
}
