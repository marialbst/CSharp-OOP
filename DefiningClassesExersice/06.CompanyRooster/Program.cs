using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CompanyRooster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();

            PrintResults(employees);
        }

        private static void PrintResults(List<Employee> employees)
        {
            
            var res = employees
                .GroupBy(x => x.Department)
                .OrderByDescending(x => x.Average(em => em.Salary))
                .First()
                .OrderByDescending(l => l.Salary)
                .ToList();

                Console.WriteLine($"Highest Average Salary: {res.Select(r => r.Department).First()} ");
                res.ForEach(em => Console.WriteLine($"{em.Name} {em.Salary:f2} {em.Email} {em.Age}"));
        }

        private static List<Employee> GetEmployees()
        {
            List<Employee> empls = new List<Employee>();

            int emplCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < emplCount; i++)
            {
                Employee empl;
                int age;
                var input = Console.ReadLine().Split();
                var name = input[0];
                var salary = decimal.Parse(input[1]);
                var position = input[2];
                var department = input[3];
                
                if (input.Length == 6)
                {
                    var mail = input[4];
                    age = int.Parse(input[5]);
                    empl = new Employee(name, salary, position, department, mail, age);
                }
                else if(input.Length == 5 && int.TryParse(input[4], out age))
                {
                    empl = new Employee(name, salary, position, department, age);
                }
                else if(input.Length == 5 && !int.TryParse(input[4], out age))
                {
                    empl = new Employee(name, salary, position, department, input[4]);
                }
                else
                {
                    empl = new Employee(name, salary, position, department);
                }

                empls.Add(empl);
            }

            return empls;
        }
    }
}
