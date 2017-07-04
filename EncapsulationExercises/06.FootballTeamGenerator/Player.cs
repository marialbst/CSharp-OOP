using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FootballTeamGenerator
{
    public class Player
    {
        private readonly List<string> statNames = new List<string> {"Endurance", "Sprint", "Dribble", "Passing", "Shooting" };
        private string name;
        private List<int> stats;

        public Player(string name)
        {
            this.Name = name;
            this.Stats = new List<int>(5);
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public List<int> Stats
        {
            get { return this.stats; }
            set
            {
                for (int i = 0; i < value.Count; i++)
                {
                    if(value[i] < 0 || value[i] > 100)
                    {
                        throw new ArgumentException($"{statNames[i]} should be between 0 and 100. ");
                    }
                }
                this.stats = value;
            }
        }

        public double GetPlayerAverageStats()
        {
            return this.Stats.Average();
        }
    }
}
