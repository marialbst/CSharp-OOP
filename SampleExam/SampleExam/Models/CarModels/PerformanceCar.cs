using System;
using System.Collections.Generic;


public class PerformanceCar : Car
{
	private List<string> addOns;
	private const int HorsePowerIncrease = 150;
	private const int SuspensionDecrease = 75;
		
	public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability ) 
		: base(brand, model, yearOfProduction, (horsepower * HorsePowerIncrease)/100, acceleration, (suspension * SuspensionDecrease) / 100, durability)
	{
		this.AddOns = new List<string>();
	}

	public List<string> AddOns
	{
		get { return this.addOns; }
		set { this.addOns = value; }
	}

	public override string ToString()
	{
		return base.ToString() + $"Add-ons: {(this.AddOns.Count > 0 ? string.Join(", ", this.AddOns) : "None")}";
	}

    public override void TuneCar(int tuneIndex, string addOn)
    {
        base.TuneCar(tuneIndex, addOn);
        this.AddOns.Add(addOn);
    }
}
