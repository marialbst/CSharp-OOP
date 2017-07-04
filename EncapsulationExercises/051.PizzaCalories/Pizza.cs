using System;
using System.Collections.Generic;

namespace _051.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private int toppingsCount;
        private List<Topping> toppings;

        public Pizza(string name, int toppingsCount)
        {
            this.Name = name;
            this.ToppingsCount = toppingsCount;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public int ToppingsCount
        {
            get { return this.toppingsCount; }
            private set
            {
                if(value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                this.toppingsCount = value;
            }
        }

        public Dough Dough
        {
            set { this.dough = value; }
        }

        public void AddToppingsToPizza(Topping topping)
        {
            this.toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            double result = this.dough.GetDoughCalories();
            this.toppings.ForEach(t => result += t.GetToppingCalories());

            return result;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.GetTotalCalories():f2} Calories.";
        }
    }
}
