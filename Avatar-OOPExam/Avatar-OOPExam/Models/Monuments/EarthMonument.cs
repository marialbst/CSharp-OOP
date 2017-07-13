public class EarthMonument : Monument
{
	private int earthAffinity;

	public EarthMonument(string name, int earthAffinity) 
		: base(name)
	{
		this.EarthAffinity = earthAffinity;
		this.Affinity = this.EarthAffinity;
	}

	public int EarthAffinity
	{
		get { return this.earthAffinity; }
		set { this.earthAffinity = value; }
	}
}

