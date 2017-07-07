using _01.Vehicles.Utilities;
using System;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public abstract double Increase { get; set; }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                Validator.IsPositiveNum(value);
                Validator.IsCapacityEnough(value, this.TankCapacity, this.FuelQuantity);
                
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            set
            {
                this.tankCapacity = value;
            }
        }

        public void Drive(double distance, bool isEmpty)
        {
            if (distance * this.FuelConsumption > this.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            if (isEmpty)
            {
                this.Increase = 0;
            }

            this.FuelQuantity -= distance * (this.FuelConsumption + this.Increase);
                
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double quantity)
        {
            Validator.IsPositiveNum(quantity);
            Validator.IsCapacityEnough(quantity, this.TankCapacity, this.FuelQuantity);

            this.FuelQuantity += quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
