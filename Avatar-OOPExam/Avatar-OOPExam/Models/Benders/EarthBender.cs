public class EarthBender : Bender
{
	private double groundSaturation;

	public EarthBender(string name, int power, double groundSaturation) 
		: base(name, power)
	{
		this.GroundSaturation = groundSaturation;
	}

	public double GroundSaturation
	{
		get { return this.groundSaturation; }
		set { this.groundSaturation = value; }
	}

	public override double GetTotalPower()
	{
		return this.Power * this.GroundSaturation;
	}

	public override string ToString()
	{
		return $"Earth {base.ToString()} Ground Saturation: {this.GroundSaturation:f2}";
	}
}

