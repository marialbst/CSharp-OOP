using System;

class Program
{
		
	static void Main(string[] args)
    {
		CarManager manager = new CarManager();

		try
		{
			var command = Console.ReadLine();

			while (command != "Cops Are Here")
			{
				var tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				switch (tokens[0])
				{
					case "register": manager.Register(int.Parse(tokens[1]), tokens[2],tokens[3],tokens[4],int.Parse(tokens[5]),int.Parse(tokens[6]), int.Parse(tokens[7]),int.Parse(tokens[8]), int.Parse(tokens[9]));break;
					case "check": Console.WriteLine(manager.Check(int.Parse(tokens[1]))); break;
					case "open": openRace(tokens, manager);break;
					case "participate": manager.Participate(int.Parse(tokens[1]), int.Parse(tokens[2]));break;
					case "start": Console.Write(manager.Start(int.Parse(tokens[1]))); break;
					case "park": manager.Park(int.Parse(tokens[1])); break;
					case "unpark": manager.Unpark(int.Parse(tokens[1])); break;
					case "tune": manager.Tune(int.Parse(tokens[1]), tokens[2]);break;
				}

				command = Console.ReadLine();
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
    }

	private static void openRace(string[] tokens, CarManager manager)
	{
		if (tokens.Length == 6)
		{
			manager.Open(int.Parse(tokens[1]), tokens[2], int.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]));
		}
		else if(tokens.Length == 7)
		{
			manager.Open(int.Parse(tokens[1]), tokens[2], int.Parse(tokens[3]), tokens[4], int.Parse(tokens[5]), int.Parse(tokens[6]));
		}
	}
}