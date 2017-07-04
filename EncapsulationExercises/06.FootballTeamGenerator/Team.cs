using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
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

        public int Rating()
        {
            return this.players.Count > 0 ? (int)Math.Round(this.players.Sum(p => p.GetPlayerAverageStats()) / this.players.Count) : 0;
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == playerName);

            if(player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team. ");
            }

            this.players.Remove(player);
        }
    }
}
