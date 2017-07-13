public class AirBender : Bender
{
	private double aerialIntegrity;
	public AirBender(string name, int power, double aerialIntegrity) 
		: base(name, power)
	{
		this.AerialIntegrity = aerialIntegrity;
	}

	public double AerialIntegrity
	{
		get { return this.aerialIntegrity; }
		set { this.aerialIntegrity = value; }
	}

	public override double GetTotalPower()
	{
		return this.Power * this.aerialIntegrity;
	}

	public override string ToString()
	{
		return $"Air {base.ToString()} Aerial Integrity: {this.AerialIntegrity:f2}";
	}
}

