namespace _05.MordorCrueltyPlan
{
    using Models;
    using Models.Foods;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            FoodFactory ff = new FoodFactory();
            var foodInput = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(f=>f.ToLower())
                .ToList();

            List<Food> foods = foodInput.Select(f => ff.CreateFood(f)).ToList();

            GandalfTheGray gray = new GandalfTheGray(foods);

            Console.WriteLine(gray);
        }
    }
}
