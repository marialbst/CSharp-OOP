using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = ReadCars();

            DriveCars(cars);

            cars.ForEach(c => Console.WriteLine(c.ToString()));
        }

        private static void DriveCars(List<Car> cars)
        {
            var command = Console.ReadLine();
            while(command != "End")
            {
                var input = command.Split();

                var model = input[1];
                var distance = double.Parse(input[2]);
                var car = cars.First(c => c.Model == model);

                if (car.IsFuelEnough(distance))
                {
                    car.CalculateFuel(distance);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                command = Console.ReadLine();
            }
        }

        private static List<Car> ReadCars()
        {
            var cars = new List<Car>();
            int carNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < carNum; i++)
            {
                var input = Console.ReadLine().Split();
                Car car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
                cars.Add(car);
            }

            return cars;
        }
    }
}
