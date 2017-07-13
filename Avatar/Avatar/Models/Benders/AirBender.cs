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
        get { return aerialIntegrity; }
        set { aerialIntegrity = value; }
    }

    public override double GetTotalPoints()
    {
        return this.AerialIntegrity * this.Power;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}
