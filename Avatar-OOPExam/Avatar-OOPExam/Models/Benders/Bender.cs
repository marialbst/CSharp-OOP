using System.Text;

public abstract class Bender
{
	private string name;
	private int power;

	public Bender(string name, int power)
	{
		this.Name = name;
		this.Power = power;
	}

	public string Name
	{
		get { return this.name; }
		private set { this.name = value; }
	}

	public int Power
	{
		get { return this.power; }
		set { this.power = value; }
	}

	public abstract double GetTotalPower();

	public override string ToString()
	{
		return $"Bender: {this.Name}, Power: {this.Power},";
	}
}

