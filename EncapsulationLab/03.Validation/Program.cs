using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int peopleCount = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < peopleCount; i++)
        {
            try
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(input[0], input[1], int.Parse(input[2]), double.Parse(input[3]));

                people.Add(person);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        var bonus = double.Parse(Console.ReadLine());

        people.ForEach(p => p.IncreaseSalary(bonus));
        people.ForEach(p => Console.WriteLine(p.ToString()));

    }
}

