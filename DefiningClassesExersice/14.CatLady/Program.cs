using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.CatLady
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>();

            var command = Console.ReadLine();

            while (command != "End")
            {
                var input = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                switch (input[0])
                {
                    case "Siamese":
                        cats.Add(new Siamese(input[1], int.Parse(input[2])));
                        break;
                    case "Cymric":
                        cats.Add(new Cymric(input[1], double.Parse(input[2])));
                        break;
                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaire(input[1], int.Parse(input[2])));
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            var catName = Console.ReadLine().Trim();
            var cat = cats.First(c => c.Name == catName);

            Console.WriteLine(cat.ToString());
        }
    }
}
