using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
	static void Main(string[] args)
	{
		AnimalManager manager = new AnimalManager();

		var command = Console.ReadLine();

		while (command != "Paw Paw Pawah")
		{
			var inputArgs = command.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

			var commandType = inputArgs[0];

			switch (commandType)
			{
				case "RegisterCleansingCenter": manager.RegisterCleansingCenter(inputArgs[1]);break;
				case "RegisterAdoptionCenter": manager.RegisterAdoptionCenter(inputArgs[1]);break;
				case "RegisterDog": manager.RegisterDog(inputArgs[1], int.Parse(inputArgs[2]), int.Parse(inputArgs[3]), inputArgs[4]); break;
				case "RegisterCat": manager.RegisterCat(inputArgs[1], int.Parse(inputArgs[2]), int.Parse(inputArgs[3]), inputArgs[4]); break;
				case "SendForCleansing": manager.SendForCleansing(inputArgs[1], inputArgs[2]); break;
				case "Cleanse": manager.CleanseAnimals(inputArgs[1]); break;
				case "Adopt": manager.AdoptAnimals(inputArgs[1]); break;
				case "RegisterCastrationCenter": manager.RegisterCastrationCenter(inputArgs[1]); break;
				case "SendForCastration": manager.SendForCastration(inputArgs[1], inputArgs[2]); break;
				case "Castrate": manager.CastrateAnimals(inputArgs[1]);break;
				case "CastrationStatistics": Console.WriteLine(manager.GetCastrationStatistics());break;
			}

			command = Console.ReadLine();
		}
		Console.WriteLine(manager.GetStatistics());
	}
}