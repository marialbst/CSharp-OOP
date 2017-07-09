namespace _03.AnimalFarm.Models.AnimalModels
{
    public class Cat : Feline
    {
        private string catBreed;

        public Cat(string animalType, string animalName, double animalWeight, string livingRegion, string catBreed) 
            : base(animalType, animalName, animalWeight, livingRegion)
        {
            this.CatBreed = catBreed;
        }

        public string CatBreed
        {
            get { return this.catBreed; }
            set { this.catBreed = value; }
        }

        public override string ToString()
        {
            return $"{this.AnimalType}[{this.AnimalName}, {this.CatBreed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

        public override string MakeASound()
        {
            return "Meowwww";
        }
    }
}
