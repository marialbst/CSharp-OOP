using System;

namespace _01.Vehicles.Utilities
{
    public static class Validator
    {
        public static double IsPositiveNum(double num)
        {
            if (num <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            return num;
        }

        public static double IsCapacityEnough(double num, double capacity, double quantity)
        {
            if(num > capacity - quantity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }

            return num;
        }

        public static double IsFuelEnough(string name, double distance, double fuel, double consumption, double increase = 0)
        {
            if (distance*(consumption + increase) > fuel)
            {
                throw new ArgumentException($"{name} needs refueling");
            }

            return distance*(consumption + increase);
        }
    }
}
