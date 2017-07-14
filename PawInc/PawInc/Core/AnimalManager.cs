using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AnimalManager
{
	private List<Center> centers;
	private List<string> cleansedAnimals;
	private List<string> adoptedAnimals;
	private List<string> castratedAnimals;
	public AnimalManager()
	{
		this.centers = new List<Center>();
		this.cleansedAnimals = new List<string>();
		this.adoptedAnimals = new List<string>();
		this.castratedAnimals = new List<string>();
	}

	public void RegisterCleansingCenter(string name)
	{
		centers.Add(new CleansingCenter(name));
	}

	public void RegisterAdoptionCenter(string name)
	{
		centers.Add(new AdoptionCenter(name));
	}

	public void RegisterDog(string name, int age, int commandsAmount, string adoptionCenterName)
	{
		Center adoptionCenter = centers.First(c => c.Name == adoptionCenterName);
		adoptionCenter.StoredAnimals.Add(new Dog(name, age, commandsAmount));
	}

	public void RegisterCat(string name, int age, int iq, string adoptionCenterName)
	{
		Center adoptionCenter = centers.First(c => c.Name == adoptionCenterName);
		adoptionCenter.StoredAnimals.Add(new Cat(name, age, iq));
	}

	public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
	{
		var adoptionCenter = centers.First(ac => ac.Name == adoptionCenterName);
		var cleansingCenter = centers.First(cc => cc.Name == cleansingCenterName);

		List<Animal> animals = adoptionCenter.StoredAnimals.Where(a => a.CleansedStatus == "UNCLEANSED").ToList();

		if (!cleansingCenter.ReceivedForTreatment.ContainsKey(adoptionCenterName))
		{
			cleansingCenter.ReceivedForTreatment.Add(adoptionCenterName, new List<Animal>());
		}

		cleansingCenter.ReceivedForTreatment[adoptionCenterName].AddRange(animals);

		animals.ForEach(a => adoptionCenter.StoredAnimals.Remove(a));
	}

	public void CleanseAnimals(string cleansingCenterName)
	{
		var center = centers.First(cc => cc.Name == cleansingCenterName);

		foreach (var item in center.ReceivedForTreatment)
		{
			var adoptionCenter = centers.First(ac => ac.Name == item.Key);
			item.Value.ForEach(a => a.ChangeCleansedStatus());
			cleansedAnimals.AddRange(item.Value.Select(a => a.GetName()));
			adoptionCenter.StoredAnimals.AddRange(item.Value);
		}

		center.ReceivedForTreatment.Clear();
	}

	public void AdoptAnimals(string adoptionCenterName)
	{
		var adoptionCenter = centers.First(ac => ac.Name == adoptionCenterName);
		adoptionCenter.StoredAnimals
			.Where(a => a.CleansedStatus == "CLEANSED")
			.ToList()
			.ForEach
			(
				a => 
				{
					adoptedAnimals.Add(a.GetName());
					adoptionCenter.StoredAnimals.Remove(a);
				}
			);
	}

	public void RegisterCastrationCenter(string name)
	{
		centers.Add(new CastrationCenter(name));
	}

	public void SendForCastration(string adoptionCenterName, string castrationCenterName)
	{
		var adoptionCenter = centers.First(ac => ac.Name == adoptionCenterName);
		var castrationCenter = centers.First(cc => cc.Name == castrationCenterName);

		List<Animal> animals = adoptionCenter.StoredAnimals;

		if (!castrationCenter.ReceivedForTreatment.ContainsKey(adoptionCenterName))
		{
			castrationCenter.ReceivedForTreatment.Add(adoptionCenterName, new List<Animal>());
		}

		castrationCenter.ReceivedForTreatment[adoptionCenterName].AddRange(animals);

		animals.Clear();
	}

	public void CastrateAnimals(string castrationCenter)
	{
		var center = centers.First(cc => cc.Name == castrationCenter);

		foreach (var item in center.ReceivedForTreatment)
		{
			var adoptionCenter = centers.First(ac => ac.Name == item.Key);
			castratedAnimals.AddRange(item.Value.Select(a => a.GetName()));
			adoptionCenter.StoredAnimals.AddRange(item.Value);
		}

		center.ReceivedForTreatment.Clear();
	}

	public string GetCastrationStatistics()
	{
		var sb = new StringBuilder();
		sb.AppendLine("Paw Inc. Regular Castration Statistics");
		sb.AppendLine($"Castration Centers: {centers.Where(c => c.GetType().Name == "CastrationCenter").Count()}");
		sb.Append($"Castrated Animals: {(this.castratedAnimals.Count > 0 ? string.Join(", ", this.castratedAnimals.OrderBy(a => a)) : "None")}");
		return sb.ToString();
	}

	public string GetStatistics()
	{
		var sb = new StringBuilder();
		sb.AppendLine("Paw Incorporative Regular Statistics");
		sb.AppendLine($"Adoption Centers: {centers.Where(c => c.GetType().Name == "AdoptionCenter").Count()}");
		sb.AppendLine($"Cleansing Centers: {centers.Where(c => c.GetType().Name == "CleansingCenter").Count()}");
		sb.AppendLine($"Adopted Animals: {(this.adoptedAnimals.Count > 0 ? string.Join(", ", this.adoptedAnimals.OrderBy(a => a)) : "None")}");
		sb.AppendLine($"Cleansed Animals: {(this.cleansedAnimals.Count > 0 ? string.Join(", ", this.cleansedAnimals.OrderBy(a => a)) : "None")}");
		sb.AppendLine($"Animals Awaiting Adoption: {centers.Sum(a => a.StoredAnimals.Where(an => an.CleansedStatus=="CLEANSED").Count())}");
		sb.Append($"Animals Awaiting Cleansing: {centers.Sum(c => c.ReceivedForTreatment.Values.Sum(a => a.Count(an => an.CleansedStatus == "UNCLEANSED")))}");
		return sb.ToString();
	}
}
