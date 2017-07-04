using System;

namespace _051.PizzaCalories
{
    public class Topping
    {
        private const double Base = 2.0;
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9; 

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        private double Weight
        {
            set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double GetToppingCalories()
        {
            double typeMod = GetTypeMod();
            return this.weight * Base * typeMod;
        }

        private double GetTypeMod()
        {
            switch (this.type.ToLower())
            {
                case "meat": return Meat;
                case "veggies": return Veggies;
                case "cheese": return Cheese;
                default: return Sauce;
            }
        }
    }
}
