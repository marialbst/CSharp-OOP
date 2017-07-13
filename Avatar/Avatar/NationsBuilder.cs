using System;
using System.Collections.Generic;
using System.Linq;

public class NationsBuilder
{
    private Nation airNation;
    private Nation fireNation;
    private Nation waterNation;
    private Nation earthNation;
    private List<Nation> nations;
    private List<string> warIssuers;
    
    public NationsBuilder()
    {
        this.airNation = new Nation("Air");
        this.earthNation = new Nation("Earth");
        this.fireNation = new Nation("Fire");
        this.waterNation = new Nation("Water");
        this.warIssuers = new List<string>();
        this.nations = new List<Nation> {this.earthNation, this.airNation, this.fireNation, this.waterNation};
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[1];
        var name = benderArgs[2];
        var power = int.Parse(benderArgs[3]);
        var param = double.Parse(benderArgs[4]);

        switch (type)
        {
            case "Air":
                airNation.Benders.Add(new AirBender(name, power, param));
                break;
            case "Fire":
                fireNation.Benders.Add(new FireBender(name, power, param));
                break;
            case "Earth":
                earthNation.Benders.Add(new EarthBender(name, power, param));
                break;
            case "Water":
                waterNation.Benders.Add(new WaterBender(name, power, param));
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[1];
        var name = monumentArgs[2];
        var affinity = int.Parse(monumentArgs[3]);

        switch (type)
        {
            case "Air":
                airNation.Monuments.Add(new AirMonument(name, affinity));
                break;
            case "Fire":
                fireNation.Monuments.Add(new FireMonument(name, affinity));
                break;
            case "Earth":
                earthNation.Monuments.Add(new EarthMonument(name, affinity));
                break;
            case "Water":
                waterNation.Monuments.Add(new WaterMonument(name, affinity));
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        return nations.First(n => n.GetNationType() == nationsType).ToString();
    }

    public void IssueWar(string nationsType)
    {
        var maxPoints = nations.Max(n => n.GetNationTotalPoints());

        nations.Where(n => n.GetNationTotalPoints() < maxPoints)
            .ToList()
            .ForEach(n => n.LoseWar());

        warIssuers.Add($"War {this.warIssuers.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, warIssuers);
    }
}