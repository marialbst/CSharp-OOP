using _03.AnimalFarm.Models.FoodModels;

namespace _03.AnimalFarm.Models.AnimalModels
{
    public abstract class Animal
    {
        private string animalName;
        private string animalType;
        private double animalWeight;
        private int foodEaten;

        public Animal(string animalType, string animalName, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
        }

        public string AnimalName
        {
            get { return this.animalName; }
            set { this.animalName = value; }
        }

        public string AnimalType
        {
            get { return this.animalType; }
            set { this.animalType = value; }
        }

        public double AnimalWeight
        {
            get { return this.animalWeight; }
            set { this.animalWeight = value; }
        }

        public int FoodEaten
        {
            get { return this.foodEaten; }
            set { this.foodEaten = value; }
        }

        public virtual string MakeASound()
        {
            return "";
        }

        public virtual void EatFood(Food food)
        {
        }

        public override string ToString()
        {
            return $"{this.AnimalType}[{this.AnimalName}, {this.AnimalWeight}, ";
        }
    }
}
