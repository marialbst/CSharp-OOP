using _06.Animals.Models;
using System;
using System.Collections.Generic;

namespace _06.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = ReadAnimals();

            animals.ForEach(a => Console.WriteLine(a));
        }

        private static List<Animal> ReadAnimals()
        {
            List<Animal> animals = new List<Animal>();

            var command = "";
            while ((command = Console.ReadLine()) != "Beast!")
            {

                try
                {
                    var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    int age;

                    if (!int.TryParse(input[1], out age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    switch (command)
                    {
                        case "Cat": animals.Add(new Cat(input[0], age, input[2])); break;
                        case "Dog": animals.Add(new Dog(input[0], age, input[2])); break;
                        case "Frog": animals.Add(new Frog(input[0], age, input[2])); break;
                        case "Kitten": animals.Add(new Kitten(input[0], age)); break;
                        default: animals.Add(new Tomcat(input[0], age)); break;
                    }

                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            return animals;
        }
    }
}
