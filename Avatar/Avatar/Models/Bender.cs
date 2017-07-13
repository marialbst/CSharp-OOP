using System;

public abstract class Bender
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public abstract double GetTotalPoints();

    public override string ToString()
    {
        var type = this.GetType().Name.Split(new string[] {"Bender"}, StringSplitOptions.RemoveEmptyEntries)[0];
        return $"###{type} Bender: {this.Name}, Power: {this.Power}";
    }
}