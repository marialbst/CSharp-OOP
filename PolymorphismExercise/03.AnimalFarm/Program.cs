using System;
using System.Collections.Generic;
using _03.AnimalFarm.Models.AnimalModels;
using _03.AnimalFarm.Models.FoodModels;

namespace _03.AnimalFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            while (command != "End")
            {
                var animalData = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                switch (animalData[0])
                {
                    case "Cat":
                        AddCat(animalData);
                        break;
                    case "Tiger":
                        AddTiger(animalData);
                        break;
                    case "Mouse":
                        AddMouse(animalData);
                        break;
                    case "Zebra":
                        AddZebra(animalData);
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void AddZebra(string[] animalData)
        {
            var zebra = new Zebra(animalData[0], animalData[1], double.Parse(animalData[2]), animalData[3]);
            Console.WriteLine(zebra.MakeASound());
            FeedAnimal(zebra);
            Console.WriteLine(zebra);

        }

        private static void AddMouse(string[] animalData)
        {
            var mouse = new Mouse(animalData[0], animalData[1], double.Parse(animalData[2]), animalData[3]);
            Console.WriteLine(mouse.MakeASound());
            FeedAnimal(mouse);
            Console.WriteLine(mouse);
        }

        private static void AddTiger(string[] animalData)
        {
            var tiger = new Tiger(animalData[0], animalData[1], double.Parse(animalData[2]), animalData[3]);
            Console.WriteLine(tiger.MakeASound());
            FeedAnimal(tiger);
            Console.WriteLine(tiger);
        }

        private static void AddCat(string[] animalData)
        {
            var cat = new Cat(animalData[0], animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
            Console.WriteLine(cat.MakeASound());
            FeedAnimal(cat);
            Console.WriteLine(cat);
        }

        private static void FeedAnimal(Mammal mammal)
        {
           Food food = ReadFood();
           mammal.EatFood(food); 
        }

        private static Food ReadFood()
        {
            var foodData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (foodData[0] == "Meat")
            {
                return new Meat(int.Parse(foodData[1]));
            }
            return new Vegetable(int.Parse(foodData[1]));
        }
    }
}
