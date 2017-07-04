using System.Collections.Generic;

namespace _13.FamilyTree
{
    public class Child
    {
        private string name;
        private string birthday;
        private List<Parent> parents;

        public Child()
        {
            this.parents = new List<Parent>();
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

        public List<Parent> Parents
        {
            get { return this.parents; }
            set { this.parents = value; }
        }
    }
}
