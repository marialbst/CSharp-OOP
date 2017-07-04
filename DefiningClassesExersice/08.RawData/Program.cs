using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = ReadCars();

            var cargoType = Console.ReadLine();

            switch (cargoType)
            {
                case "fragile": PrintFragileCars(cargoType, cars); break;
                case "flamable": PrintFlamableCars(cargoType, cars); break;
                default:
                    break;
            }
        }

        private static void PrintFlamableCars(string cargoType, List<Car> cars)
        {
            cars.Where(c => c.Cargo.Type == cargoType && c.Engine.Power > 250)
                .ToList()
                .ForEach(c => Console.WriteLine(c.ToString()));
        }

        private static void PrintFragileCars(string cargoType, List<Car> cars)
        {
            cars.Where(c => c.Cargo.Type == cargoType && c.Tyres.Any(t => t.Pressure < 1))
                .ToList()
                .ForEach(c => Console.WriteLine(c.ToString()));
        }

        private static List<Car> ReadCars()
        {
            var cars = new List<Car>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();

                int engSpeed = int.Parse(input[1]);
                int engPower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);

                var engine = new Engine(engSpeed, engPower);
                var cargo = new Cargo(cargoWeight, input[4]);
                var tyres = new List<Tyre>(4);

                for (int j = 5; j < input.Length; j+=2)
                {
                    var tyre = new Tyre(int.Parse(input[j+1]), double.Parse(input[j]));

                    tyres.Add(tyre);
                }

                var car = new Car(input[0], cargo, engine, tyres);
                cars.Add(car);
            }

            return cars;
        }
    }
}
