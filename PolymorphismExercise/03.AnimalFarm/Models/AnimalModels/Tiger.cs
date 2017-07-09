using System;
using _03.AnimalFarm.Models.FoodModels;

namespace _03.AnimalFarm.Models.AnimalModels
{
    public class Tiger : Feline
    {
        public Tiger(string animalType, string animalName, double animalWeight, string livingRegion) 
            : base(animalType, animalName, animalWeight, livingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name == "Vegetable")
            {
                Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }
        }

        public override string MakeASound()
        {
            return "ROAAR!!!";
        }
    }
}
