using System;

public class ShowCar : Car
{
	private int stars;

	public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
		: base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
	{
		this.Stars = stars;
	}

	public int Stars
	{
		get { return this.stars; }
		set { this.stars = value; }
	}

	public override string ToString()
	{
		return base.ToString() + $"{this.Stars} *";
	}

    public override void TuneCar(int tuneIndex, string addOn)
    {
        base.TuneCar(tuneIndex, addOn);
        this.Stars += tuneIndex;
    }
}

