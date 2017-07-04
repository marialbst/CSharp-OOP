using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<Person>  people = GetPeople(peopleCount);

            people.Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
        }

        private static List<Person> GetPeople(int peopleCount)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            return people;
        }
    }
}
