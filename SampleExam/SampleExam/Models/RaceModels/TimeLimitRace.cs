using System;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
	private int goldTime;
	private int moneyWon;

	public TimeLimitRace(int length, string route, int prizePool, int goldTime) 
		: base(length, route, prizePool)
	{
		this.GoldTime = goldTime;
	}

	public int GoldTime
	{
		get { return this.goldTime; }
		set { this.goldTime = value; }
	}

	public override int GetPerformancePoints(Car car)
	{
		return this.Length * ((car.Horsepower / 100) * car.Acceleration);
	}

	public override string ToString()
	{
		var sb = new StringBuilder();
		var part = this.Participants.First();
		sb.AppendLine($"{this.Route} - {this.Length}")
			.AppendLine($"{part.Brand} {part.Model} - {this.GetPerformancePoints(part)} s.")
			.AppendLine($"{this.GetTimeType(part)} Time, ${this.moneyWon}.")
            .AppendLine();
		return sb.ToString();
	}

	private string GetTimeType(Car car)
	{
		if (this.GetPerformancePoints(car) <= this.GoldTime)
		{
			moneyWon = this.PrizePool;
			return "Gold";
		}
		else if (this.GetPerformancePoints(car) <= this.GoldTime + 15)
		{
			moneyWon = this.GetFirstPlaceAward();
			return "Silver";
		}
		moneyWon = this.GetSecondPlaceAward();
		return "Bronze";
	}
}
