using System;
using _01.Vehicles.Utilities;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        protected double Increase { get; set; }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                Validator.IsPositiveNum(value);
                               
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            protected set { this.fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            protected set
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
            double result = 0;
            if (isEmpty)
            {
                result = Validator.IsFuelEnough(this.GetType().Name, distance, this.FuelQuantity, this.FuelConsumption);
                
            }
            else
            {
                result = Validator.IsFuelEnough(this.GetType().Name, distance, this.FuelQuantity, this.FuelConsumption, this.Increase);
            }

            this.FuelQuantity -= result;
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
