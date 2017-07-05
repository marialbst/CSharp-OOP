using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            :base(firstName,lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {//8 test - za regex, 6 - по-дълъг от 10 символа стринг с разрешени символи
                Regex rg = new Regex(@"^[A-Za-z0-9]{5,10}$");
                if (!rg.IsMatch(value))
                {//нулев 1, 5, 6 и 7 тест
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString())
                .AppendLine($"Faculty number: {this.FacultyNumber}");

            return sb.ToString();
        }
    }
}
