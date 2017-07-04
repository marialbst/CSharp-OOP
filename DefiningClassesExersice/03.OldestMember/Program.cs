using System;
using System.Reflection;

namespace _03.OldestMember
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }

            ReadPeople();
        }

        private static void ReadPeople()
        {
            int membersCount = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < membersCount; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);

                family.AddMember(person);
            }

            var oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
}
