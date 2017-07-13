public class FireBender : Bender
{
	private double heatAgression;

	public FireBender(string name, int power, double heatAgression) 
		: base(name, power)
	{
		this.HeatAgression = heatAgression;
	}

	public double HeatAgression
	{
		get { return this.heatAgression; }
		set { this.heatAgression = value; }
	}
	public override double GetTotalPower()
	{
		return this.Power * this.HeatAgression;
	}

	public override string ToString()
	{
		return $"Fire {base.ToString()} Heat Aggression: {this.HeatAgression:f2}";
	}
}

