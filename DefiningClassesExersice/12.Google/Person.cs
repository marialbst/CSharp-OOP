using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Google
{
    public class Person
    {
        private string name;
        private Car car;
        private Company company;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Child> children;

        public Person(string name)
        {
            this.name = name;
            this.children = new List<Child>();
            this.parents = new List<Parent>();
            this.pokemons = new List<Pokemon>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Car Car
        {
            get { return this.car; }
            set { this.car = value; }
        }

        public Company Company
        {
            get { return this.company; }
            set { this.company = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public List<Parent> Parents
        {
            get { return this.parents; }
            set { this.parents = value; }
        }

        public List<Child> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public override string ToString()
        {
            var compRes = this.Company == null ? "" : $"{this.Company.CompanyName} {this.Company.Department} {this.Company.Salary:f2}\n";
            var carRes = this.Car == null ? "" : $"{this.Car.Model} {this.Car.Speed}\n";
            string result = $"{this.Name}\nCompany:\n{compRes}";
            result += $"Car:\n{carRes}Pokemon:\n";

            foreach (var pokemon in this.Pokemons)
            {
                result += $"{pokemon.Name} {pokemon.Type}\n";
            }
            result += "Parents:\n";
            foreach (var parent in this.Parents)
            {
                result += $"{parent.Name} {parent.Birthday}\n";
            }
            result += "Children:\n";

            foreach (var child in this.Children)
            {
                result += $"{child.Name} {child.Birthday}\n";
            }

            return result;
        }
    }
}
