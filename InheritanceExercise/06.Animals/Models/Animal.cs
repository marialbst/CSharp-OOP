using System;
using System.Text;

namespace _06.Animals.Models
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get { return this.gender; }
            set
            {
                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return "";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}")
                .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                .Append(this.ProduceSound());

            return sb.ToString();
        }
    }
}
