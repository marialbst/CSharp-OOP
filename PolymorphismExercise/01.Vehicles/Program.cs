using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = ReadVehicles();

            DoActions(vehicles);

            vehicles.ForEach(v => Console.WriteLine(v));
        }

        private static void DoActions(List<Vehicle> vehicles)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = command[1];
                double val = double.Parse(command[2]);

                switch (command[0])
                {
                    case "Drive": Drive(vehicles, type, val); break;
                    case "Refuel": Refuel(vehicles, type, val); break;
                }
            }
        }

        private static void Refuel(List<Vehicle> vehicles, string type, double quantity)
        {
            switch (type)
            {
                case "Car": vehicles[0].Refuel(quantity); break;
                case "Truck": vehicles[1].Refuel(quantity); break;
            }
        }

        private static void Drive(List<Vehicle> vehicles, string type, double distance)
        {
            switch (type)
            {
                case "Car": vehicles[0].Drive(distance); break;
                case "Truck": vehicles[1].Drive(distance); break;
            }
        }

        private static List<Vehicle> ReadVehicles()
        {
            List<Vehicle> veh = new List<Vehicle>();

            for (int i = 0; i < 2; i++)
            {
                var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                double[] carData = input.Skip(1)
                                        .Select(double.Parse)
                                        .ToArray();

                switch (input[0])
                {
                    case "Car": veh.Add(new Car(carData[0], carData[1])); break;
                    case "Truck": veh.Add(new Truck(carData[0], carData[1])); break;
                    default: throw new Exception();
                }
            }
            return veh;
        }
    }
}
