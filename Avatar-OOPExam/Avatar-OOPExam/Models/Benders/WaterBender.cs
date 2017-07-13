public class WaterBender : Bender
{
	private double waterClarity;

	public WaterBender(string name, int power, double waterClarity) 
		: base(name, power)
	{
		this.Waterclarity = waterClarity;
	}

	public double Waterclarity
	{
		get { return this.waterClarity; }
		set { this.waterClarity = value; }
	}
	public override double GetTotalPower()
	{
		return this.Power * this.Waterclarity;
	}

	public override string ToString()
	{
		return $"Water {base.ToString()} Water Clarity: {this.Waterclarity:f2}";
	}
}

