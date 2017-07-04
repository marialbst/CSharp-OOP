using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = GetEngines();

            List<Car> cars = GetCars(engines);

            cars.ForEach(c => Console.WriteLine(c.ToString()));
        }

        private static List<Car> GetCars(List<Engine> engines)
        {
            List<Car> cars = new List<Car>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var carModel = input[0];
                var engineModel = input[1];
                var engine = engines.First(e => e.Model == engineModel);
                Car car;
                int weight;

                if (input.Length==2)
                {
                    car = new Car(carModel, engine);
                }
                else if(input.Length == 3 && int.TryParse(input[2], out weight))
                {
                    car = new Car(carModel, engine, weight);
                }
                else if(input.Length == 3 && !int.TryParse(input[2], out weight))
                {
                    car = new Car(carModel, engine, input[2]);
                }
                else
                {
                    car = new Car(carModel, engine, int.Parse(input[2]), input[3]);
                }

                cars.Add(car);
            }

            return cars;
        }

        private static List<Engine> GetEngines()
        {
            List<Engine> engines = new List<Engine>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int power = int.Parse(input[1]);
                int displacement;
                Engine eng;

                if (input.Length == 2)
                {
                    eng = new Engine(model, power);
                }
                else if(input.Length == 3 && int.TryParse(input[2], out displacement))
                {
                    eng = new Engine(model, power, displacement);
                }
                else if(input.Length == 3 && !int.TryParse(input[2], out displacement))
                {
                    eng = new Engine(model, power, input[2]);
                }
                else
                {
                    eng = new Engine(model, power, int.Parse(input[2]), input[3]);
                }

                engines.Add(eng);
            }

            return engines;
        }
    }
}
