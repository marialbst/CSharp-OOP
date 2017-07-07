using System;
using System.Collections.Generic;
using System.Linq;
using _01.Vehicles.Models;

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

                try
                { 
                    switch (command[0])
                    {
                        case "Drive": vehicles.First(v => v.GetType().Name == type).Drive(val, false); break;
                        case "DriveEmpty": vehicles.First(v => v.GetType().Name == "Bus").Drive(val, true); break;
                        case "Refuel": vehicles.First(v => v.GetType().Name == type).Refuel(val); break;
                        default: throw new ArgumentException("Invalid input");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static List<Vehicle> ReadVehicles()
        {
            List<Vehicle> veh = new List<Vehicle>();

            for (int i = 0; i < 3; i++)
            {
                 var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    double[] carData = input.Skip(1)
                        .Select(double.Parse)
                        .ToArray();

                    switch (input[0])
                    {
                        case "Car":
                            veh.Add(new Car(carData[0], carData[1], carData[2]));
                            break;
                        case "Truck":
                            veh.Add(new Truck(carData[0], carData[1], carData[2]));
                            break;
                        case "Bus":
                            veh.Add(new Bus(carData[0], carData[1], carData[2]));
                            break;
                        default:
                            throw new ArgumentException("Invalid input");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return veh;
        }
    }
}
