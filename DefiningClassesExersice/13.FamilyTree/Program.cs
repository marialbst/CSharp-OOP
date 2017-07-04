using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _13.FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string datePattern = @"(\d+\/\d+\/\d+)";
            Regex regex = new Regex(datePattern);
            List<Person> family = new List<Person>();

            var personData = Console.ReadLine();

            List<string> partialParentData = new List<string>();
            List<string> partialChildData = new List<string>();

            ReadFamilyData(family, partialParentData, partialChildData);

            for (int i = 0; i < partialParentData.Count; i++)
            {
                Person parent;
                Person child;

                if (regex.IsMatch(partialParentData[i]))
                {
                    parent = family.First(p => p.Birthday == partialParentData[i]);
                }
                else
                {
                    parent = family.First(p => p.Name == partialParentData[i]);
                }

                if (regex.IsMatch(partialChildData[i]))
                {
                    child = family.First(c => c.Birthday == partialChildData[i]);
                }
                else
                {
                    child = family.First(c => c.Name == partialChildData[i]);
                }

                if (!parent.Children.Contains(child))
                {
                    parent.Children.Add(child);
                }

                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }
            }
            Person mainPerson = ReadMainPerson(regex, family, personData);
            Console.Write(mainPerson.ToString());
        }

        private static void ReadFamilyData(List<Person> family, List<string> partialParentData, List<string> partialChildData)
        {
            var command = Console.ReadLine();
            while (command != "End")
            {
                var input = Regex.Split(command, " - ");

                if (input.Length == 1)
                {
                    var lastIndexOfSpace = input[0].LastIndexOf(" ");
                    var person = new Person();
                    person.Name = input[0].Substring(0, lastIndexOfSpace);
                    person.Birthday = input[0].Substring(lastIndexOfSpace + 1);

                    family.Add(person);
                }
                else
                {
                    partialParentData.Add(input[0]);
                    partialChildData.Add(input[1]);
                }
                command = Console.ReadLine();
            }
        }

        private static Person ReadMainPerson(Regex regex, List<Person> family, string personData)
        {
            Person mainPerson;
            
            if (regex.IsMatch(personData))
            {
                mainPerson = family.First(p => p.Birthday == personData);
            }
            else
            {
                mainPerson = family.First(p => p.Name == personData);
            }
            
            return mainPerson;
        }
    }
}
