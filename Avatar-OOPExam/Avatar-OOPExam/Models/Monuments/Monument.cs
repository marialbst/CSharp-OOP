public abstract class Monument
{
	private string name;
	private int affinity;

	public Monument(string name)
	{
		this.Name = name;
	}

	public string Name
	{
		get { return this.name; }
		set { this.name = value; }
	}

	public int Affinity
	{
		get { return this.affinity; }
		set { this.affinity = value; }
	}
}
