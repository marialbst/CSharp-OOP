using System.Linq;
using System.Text;

public class CircuitRace : CasualRace
{
	private int laps;
	private int moneyWon;

	public CircuitRace(int length, string route, int prizePool, int laps) 
		: base(length, route, prizePool)
	{
		this.Laps = laps;
	}

	public int Laps
	{
		get { return this.laps; }
		set { this.laps = value; }
	}

	public override string ToString()
	{
		var sb = new StringBuilder();
		var racers = this.Participants
			.OrderByDescending(p => this.GetPerformancePoints(p))
			//.ThenBy(p=>p)
			.Take(4)
			.ToList();
		sb.AppendLine($"{this.Route} - {this.Length * this.Laps}");
		for (int i=0; i < racers.Count(); i++)
		{
			switch (i)
			{
				case 0: moneyWon = (this.PrizePool * 40) / 100; break;
				case 1: moneyWon = (this.PrizePool * 30) / 100; break;
				case 2: moneyWon = (this.PrizePool * 20) / 100; break;
				case 3: moneyWon = (this.PrizePool * 10) / 100; break;
			}

			sb.AppendLine($"{i + 1}. {racers[i].Brand} {racers[i].Model} {this.GetPerformancePoints(racers[i])}PP - ${this.moneyWon}");
		}

		return sb.ToString().Trim();
	}
}

