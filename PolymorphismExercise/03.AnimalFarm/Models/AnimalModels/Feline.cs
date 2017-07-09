using _03.AnimalFarm.Models.FoodModels;

namespace _03.AnimalFarm.Models.AnimalModels
{
    public class Feline : Mammal
    {
        public Feline(string animalName, string animalType, double animalWeight, string livingRegion) 
            : base(animalName, animalType, animalWeight, livingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            this.FoodEaten += food.Quantity;
        }
    }
}
