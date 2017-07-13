using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder builder;

    public Engine()
    {
        this.builder = new NationsBuilder();
    }

    public void Run()
    {
        string command = Console.ReadLine();

        while (command != "Quit")
        {
            List<string> inputArgs = ParseCommand(command);

            ProcessCommand(inputArgs);

            command = Console.ReadLine();
        }

        Console.WriteLine(builder.GetWarsRecord());
    }

    private void ProcessCommand(List<string> inputArgs)
    {
        var command = inputArgs[0];

        switch (command)
        {
            case "Bender":
                builder.AssignBender(inputArgs);
                break;
            case "Monument":
                builder.AssignMonument(inputArgs);
                break;
            case "War":
                builder.IssueWar(inputArgs[1]);
                break;
            case "Status":
                Console.WriteLine(builder.GetStatus(inputArgs[1]));
                break;
        }
    }

    private List<string> ParseCommand(string command)
    {
        return command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}