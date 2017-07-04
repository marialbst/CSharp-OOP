using System;
using System.Reflection;

//namespace _01.DefineClassPerson
//{
    class Program
    {
        static void Main(string[] args)
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            var person1 = new Person();
            person1.age = 20;
            person1.name = "Pesho";
            var person2 = new Person
            {
                age = 18,
                name = "Gosho"
            };

            var person3 = new Person
            {
                age = 43,
                name = "Stamat"
            };
        }
    }
//}
