public abstract class Animal
{
	private const string Uncleansed = "UNCLEANSED";
	private const string Cleansed = "CLEANSED";

	private string name;
	private int age;
	private string cleansedStatus;

	public Animal(string name, int age)
	{
		this.name = name;
		this.age = age;
		this.cleansedStatus = Uncleansed;
	}

	public string GetName()
	{
		return this.name;
	}
	
	public string CleansedStatus
	{
		get { return this.cleansedStatus; }
	}

	public void ChangeCleansedStatus()
	{
		this.cleansedStatus = Cleansed;
	}
}