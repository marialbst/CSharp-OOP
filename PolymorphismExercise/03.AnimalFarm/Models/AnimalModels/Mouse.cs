namespace _03.AnimalFarm.Models.AnimalModels
{
    public class Mouse : Mammal
    {
        public Mouse(string animalType, string animalName, double animalWeight, string livingRegion) 
            : base(animalType, animalName, animalWeight, livingRegion)
        {
        }

        public override string MakeASound()
        {
            return "SQUEEEAAAK!";
        }
    }
}
