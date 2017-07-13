using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

public class NationsBuilder
{
	private List<string> warIssuers;
	private Air airNation;
	private Fire fireNation;
	private Water waterNation;
	private Earth earthNation;

	private HashSet<Nation> nations;

	public NationsBuilder()
	{
		this.warIssuers = new List<string>();
		this.airNation = new Air();
		this.earthNation = new Earth();
		this.fireNation = new Fire();
		this.waterNation = new Water();
		this.nations = new HashSet<Nation>();
	}

	public void AssignBender(List<string> benderArgs)
	{
		var type = benderArgs[1];
		var name = benderArgs[2];
		var power = int.Parse(benderArgs[3]);
		var param = double.Parse(benderArgs[4], CultureInfo.InvariantCulture);

		switch (type)
		{
			case "Air": airNation.Benders.Add(new AirBender(name, power, param)); nations.Add(airNation); break;
			case "Fire": fireNation.Benders.Add(new FireBender(name, power, param)); nations.Add(fireNation); break;
			case "Water": waterNation.Benders.Add(new WaterBender(name, power, param)); nations.Add(waterNation); break;
			case "Earth": earthNation.Benders.Add(new EarthBender(name, power, param)); nations.Add(earthNation); break;
		}

	}
	public void AssignMonument(List<string> monumentArgs)
	{
		var type = monumentArgs[1];
		var name = monumentArgs[2];
		var affinity = int.Parse(monumentArgs[3]);

		switch (type)
		{
			case "Air": airNation.Monuments.Add(new AirMonument(name, affinity)); nations.Add(airNation); break;
			case "Fire": fireNation.Monuments.Add(new FireMonument(name, affinity)); nations.Add(fireNation); break;
			case "Water": waterNation.Monuments.Add(new WaterMonument(name, affinity)); nations.Add(waterNation); break;
			case "Earth": earthNation.Monuments.Add(new EarthMonument(name, affinity)); nations.Add(earthNation); break;
		}
	}
	public string GetStatus(string nationsType)
	{
		Nation nation = nations.First(n => n.GetType().Name == nationsType);
		
		return nation.ToString();
	}

	public void IssueWar(string nationsType)
	{
		warIssuers.Add(nationsType);
		var maxPoints = double.MinValue;
		foreach (var nation in nations)
		{
			if (nation.GetWarPoints() > maxPoints)
			{
				maxPoints = nation.GetWarPoints();
			}
		}

		nations.Where(nt => nt.GetWarPoints() != maxPoints)
			.ToList()
			.ForEach(m => { m.Monuments.Clear(); m.Benders.Clear();});

		////add more logic
		//var n = nations.ToList();
		//var firstNation = n[0];
		//for (int i = 1; i < nations.Count; i++)
		//{
		//	var secondNation = n[i];

		//	if (firstNation.GetWarPoints() > secondNation.GetWarPoints())
		//	{
		//		secondNation.Benders = new List<Bender>();
		//		secondNation.Monuments = new List<Monument>();
		//	}
		//	else
		//	{
		//		firstNation.Benders = new List<Bender>();
		//		firstNation.Monuments = new List<Monument>();
		//		firstNation = secondNation;
		//	}
		//}
	}
	public string GetWarsRecord()
	{
		var sb = new StringBuilder();

		for (int i = 0; i < warIssuers.Count; i++)
		{
			sb.AppendLine($"War {i + 1} issued by {this.warIssuers[i]}");
		}

		return sb.ToString().Trim();
	}
}

