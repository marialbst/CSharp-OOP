using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = ReadTrainers();
            AddBadges(trainers);

            trainers.OrderByDescending(t => t.Badges).ToList().ForEach(t => Console.WriteLine(t.ToString()));
        }

        private static void AddBadges(List<Trainer> trainers)
        {
            var command = Console.ReadLine();

            while (command != "End")
            {
                trainers.Where(t => t.Pokemons.Any(p => p.Element == command))
                    .ToList()
                    .ForEach(t => t.Badges++);

                var result = trainers.Where(t => t.Pokemons.All(p => p.Element != command))
                     .ToList();

                foreach (var item in result)
                {
                    item.Pokemons.ForEach(p => p.Health -= 10);

                    List<Pokemon> toRemove = item.Pokemons.Where(p => p.Health <= 0).ToList();

                    foreach (var pokemon in toRemove)
                    {
                        item.Pokemons.Remove(pokemon);
                    }
                }

                command = Console.ReadLine();
            }
        }

        private static List<Trainer> ReadTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();
            var command = Console.ReadLine();

            while(command != "Tournament")
            {
                var input = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                var trainerName = input[0];
                Trainer trainer = trainers.Where(t => t.Name == trainerName).FirstOrDefault();

                var pokemonName = input[1];
                var pokemonElement = input[2];
                var health = int.Parse(input[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, health);

                if (trainer == null)
                {
                    List<Pokemon> pokemons = new List<Pokemon> { pokemon };
                    trainer = new Trainer(trainerName, pokemons);
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(pokemon);
                }

               
                command = Console.ReadLine();
            }

            return trainers;
        }
    }
}
