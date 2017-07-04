using System.Collections.Generic;

namespace _11.PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer(string name, List<Pokemon> pokemons)
        {
            this.name = name;
            this.pokemons = pokemons;
            this.badges = 0;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Badges
        {
            get { return this.badges; }
            set { this.badges = value; }
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
