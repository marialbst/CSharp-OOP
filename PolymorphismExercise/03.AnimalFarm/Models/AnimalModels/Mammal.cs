using System;
using _03.AnimalFarm.Models.FoodModels;

namespace _03.AnimalFarm.Models.AnimalModels
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string animalName, string animalType, double animalWeight, string livingRegion) : 
            base(animalName, animalType, animalWeight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return this.livingRegion; }
            set { this.livingRegion = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.LivingRegion}, {this.FoodEaten}]";
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name == "Meat")
            {
                Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }
        }
    }
}
