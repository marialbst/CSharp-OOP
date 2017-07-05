using System;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = ReadStudent();
                Worker worker = ReadWorker();

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Worker ReadWorker()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new Worker(input[0], input[1], decimal.Parse(input[2]), decimal.Parse(input[3]));
        }

        private static Student ReadStudent()
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            return new Student(input[0], input[1], input[2]);
        }
    }
}
