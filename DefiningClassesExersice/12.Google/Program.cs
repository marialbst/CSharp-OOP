using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();

            var personName = Console.ReadLine().Trim();

            Console.WriteLine(people.First(p => p.Name == personName).ToString());
        }

        private static List<Person> ReadPeople()
        {
            List<Person> ppl = new List<Person>();
            var command = Console.ReadLine();

            while (command != "End")
            {
                var tokens = command.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var typeBelonging = tokens[1];
                Person person = GetPersonByName(ppl, tokens[0]);

                switch (typeBelonging)
                {
                    case "company":
                        AddCompany(person, tokens[2], tokens[3], double.Parse(tokens[4]));
                        break;
                    case "car":
                        AddCars(person, tokens[2], int.Parse(tokens[3]));
                        break;
                    case "pokemon":
                        AddPokemon(person, tokens[2], tokens[3]);
                        break;
                    case "parents":
                        AddParent(person, tokens[2], tokens[3]);
                        break;
                    case "children":
                        AddChild(person, tokens[2], tokens[3]);
                        break;
                }

                command = Console.ReadLine();
            }

            return ppl;
        }

        private static void AddChild(Person person, string name, string birthday)
        {
            person.Children.Add(new Child(name, birthday));
        }

        private static void AddParent(Person person, string name, string birthday)
        {
            person.Parents.Add(new Parent(name, birthday));
        }

        private static void AddPokemon(Person person, string name, string type)
        {
            person.Pokemons.Add(new Pokemon(name, type));
        }

        private static void AddCars(Person person, string model, int speed)
        {
            person.Car = new Car(model, speed);
        }

        private static void AddCompany(Person person, string compName, string department, double salary)
        {
            person.Company = new Company(compName,department,salary);
        }
        
        private static Person GetPersonByName(List<Person> ppl, string name)
        {
            var person = ppl.FirstOrDefault(p => p.Name == name);

            if (person == null)
            {
                person = new Person(name);
                ppl.Add(person);
            }
            return person;
        }
    }
}
