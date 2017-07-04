using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.FamilyTree
{
    public class Person
    {
        private string name;
        private string birthday;
        private List<Person> parents;
        private List<Person> children;

        public Person()
        {
            this.parents = new List<Person>();
            this.children = new List<Person>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public List<Person> Parents
        {
            get { return this.parents; }
            set { this.parents = value; }
        }
        public List<Person> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} {this.Birthday}");
            sb.AppendLine($"Parents:");
            foreach (var parent in this.Parents)
            {
                sb.AppendLine($"{parent.Name} {parent.Birthday}");
            }
            sb.AppendLine("Children:");
            foreach (var child in this.Children)
            {
                sb.AppendLine($"{child.Name} {child.Birthday}");
            }

            return sb.ToString();
        }
    }
}
