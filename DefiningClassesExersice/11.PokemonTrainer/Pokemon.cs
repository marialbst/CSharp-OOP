namespace _11.PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string name, string element, int health)
        {
            this.health = health;
            this.name = name;
            this.element = element;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public int Health
        {
            get { return this.health; }
            set {
                    this.health = value;
                }
        }
    }
}
