using System;

namespace _05.DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            var result = DateModifier.DifferenceBetweenDays(date1, date2);

            Console.WriteLine(result);
        }
    }
}
