using System;

namespace _05.PizzaCalories
{
    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;
        private const double Base = 2.0;

        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get { return this.type; }
            set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        private int Weight
        {
            get { return this.weight; }
            set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double CalculateToppingCalories()
        {
            double cal = Base * this.weight;
            double modifier = GetModifier();
            
            return cal * modifier;
        }

        private double GetModifier()
        {
            switch (this.type.ToLower())
            {
                case "meat":return Meat;
                case "veggies": return Veggies; 
                case "cheese": return Cheese; 
                default: return Sauce; 
            }
        }
    }
}
