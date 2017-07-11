using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
	private int length;
	private string route;
	private int prizePool;
	//check if List<int> with ids will work instead of dictionary
	private List<Car> participants;

	public Race(int length, string route, int prizePool)
	{
		this.Length = length;
		this.Route = route;
		this.PrizePool = prizePool;
		this.participants = new List<Car>();
	}

	public int Length
	{
		get { return this.length; }
		private set { this.length = value; }
	}

	public string Route
	{
		get { return this.route; }
		private set { this.route = value; }
	}

	public int PrizePool
	{
		get { return this.prizePool; }
		private set { this.prizePool = value; }
	}

	public List<Car> Participants
	{
		get {return this.participants; }
		set { this.participants = value; }
	}

	public override string ToString()
	{
			
		var sb = new StringBuilder();
		sb.AppendLine($"{this.Route} - {this.Length}");
		List<Car> winners = this.Participants
			.OrderByDescending(p => this.GetPerformancePoints(p))
			//.ThenBy(p => p)
			.Take(3)
			.ToList();

		for (int i = 0; i < winners.Count; i++)
		{
			var money = 0;

			if (i == 0)
			{
				money = this.GetFirstPlaceAward();
			}
			else if (i == 1)
			{
				money = this.GetSecondPlaceAward();
			}
			else
			{
				money = this.GetThirdPlaceAward();
			}
			sb.AppendLine($"{i + 1}. {winners[i].Brand} {winners[i].Model} {this.GetPerformancePoints(winners[i])}PP - ${money}");
		}

		return sb.ToString();
	}
		

	public abstract int GetPerformancePoints(Car car);

	public virtual int GetFirstPlaceAward()
	{
		return this.PrizePool * 50 / 100;
	}

	public virtual int GetSecondPlaceAward()
	{
		return this.PrizePool * 30 / 100;
	}

	public virtual int GetThirdPlaceAward()
	{
		return this.PrizePool * 20 / 100;
	}
}