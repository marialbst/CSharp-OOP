using System;
using System.Linq;

class StartUp
{
	static void Main(string[] args)
	{
		NationsBuilder builder = new NationsBuilder();

		var command = Console.ReadLine();

		while (command != "Quit")
		{
			var inputArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

			switch (inputArgs[0])
			{
				case "Bender":
					builder.AssignBender(inputArgs); break;
				case "Monument":
					builder.AssignMonument(inputArgs); break;
				case "Status":
					Console.WriteLine(builder.GetStatus(inputArgs[1])); break;
				case "War":
					builder.IssueWar(inputArgs[1]); break;
				default:
					break;
			}
			command = Console.ReadLine();
			
		}

		Console.WriteLine(builder.GetWarsRecord());
	}
}

