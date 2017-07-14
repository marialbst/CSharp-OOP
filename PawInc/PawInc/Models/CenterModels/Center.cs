using System.Collections.Generic;

public abstract class Center
{
	private string name;
	private Dictionary<string, List<Animal>> receivedForTreatment;
	private List<Animal> storedAnimals;

	public Center(string name)
	{
		this.Name = name;
		this.ReceivedForTreatment = new Dictionary<string, List<Animal>>();
		this.StoredAnimals = new List<Animal>();
	}

	public string Name
	{
		get { return this.name; }
		set { this.name = value; }
	}

	public List<Animal> StoredAnimals
	{
		get { return this.storedAnimals; }
		set { this.storedAnimals = value; }
	}

	public Dictionary<string, List<Animal>> ReceivedForTreatment
	{
		get { return this.receivedForTreatment; }
		set { this.receivedForTreatment = value; }
	}
}
