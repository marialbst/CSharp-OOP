using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = "";
            List<Team> teams = new List<Team>();
            while((command = Console.ReadLine()) != "END")
            {
                try
                {
                    var tokens = command.Split(';');

                    switch (tokens[0])
                    {
                        case "Team": AddTeam(tokens,teams); break;
                        case "Add": AddPlayer(tokens,teams);break;
                        case "Remove": RemovePlayer(tokens,teams);break;
                        case "Rating": ShowRating(tokens,teams);break;
                    }
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ShowRating(string[] tokens, List<Team> teams)
        {
            var teamName = tokens[1];
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Console.WriteLine($"{team.Name} - {team.Rating()}");
        }

        private static void RemovePlayer(string[] tokens, List<Team> teams)
        {
            var teamName = tokens[1];
            var playerName = tokens[2];

            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            team.RemovePlayer(playerName);
        }

        private static void AddPlayer(string[] tokens, List<Team> teams)
        {
            var teamName = tokens[1];
            var playerName = tokens[2];
            List<int> stats = tokens.Skip(3).Take(5).Select(int.Parse).ToList();

            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Player player = new Player(playerName);
            player.Stats = stats;

            team.AddPlayer(player);
        }

        private static void AddTeam(string[] tokens, List<Team> teams)
        {
            var name = tokens[1];
            Team team = new Team(name);
            teams.Add(team);
        }
    }
}
