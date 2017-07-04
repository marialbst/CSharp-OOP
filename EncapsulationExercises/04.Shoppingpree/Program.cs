using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.Shoppingpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            var command = Console.ReadLine();

            while(command != "END")
            {
                var tokens = command.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var person = people.First(p => p.Name == tokens[0]);
                var product = products.First(p => p.Name == tokens[1]);

                var result = person.TryBuyProducts(product);

                Console.WriteLine(result);

                command = Console.ReadLine();
            }

            people.ForEach(p => Console.WriteLine(p.ToString()));
        }

        private static List<Product> ReadProducts()
        {
            List<Product> products = new List<Product>();

            var data = Console.ReadLine().Split(new[] {' ', ';'}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string pair in data)
            {
                var entry = pair.Split('=');

                var name = entry[0];
                var money = double.Parse(entry[1]);

                var product = new Product(name, money);
                products.Add(product);
            }

            return products;
        }

        private static List<Person> ReadPeople()
        {
            List<Person> people = new List<Person>();

            var data = Console.ReadLine().Split(';');

            foreach (string pair in data)
            {
                var entry = pair.Split('=');

                var name = entry[0].Trim();
                var money = double.Parse(entry[1]);

                var person = new Person(name, money);
                people.Add(person);
            }

            return people;
        }
    }
}
