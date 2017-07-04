using System.Collections.Generic;

namespace _13.FamilyTree
{
    public class Parent
    {
        private string name;
        private string birthday;
        private List<Child> children;

        public Parent()
        {
            this.children = new List<Child>();
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

        public List<Child> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }
    }
}
