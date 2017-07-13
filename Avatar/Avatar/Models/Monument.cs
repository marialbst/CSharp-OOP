using System;

public abstract class Monument
{
    private string name;

    public Monument(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public abstract int GetAffinity();

    public override string ToString()
    {
        var type = this.GetType().Name.Split(new string[] {"Monument"}, StringSplitOptions.RemoveEmptyEntries)[0];
        return $"###{type} Monument: {this.Name}, {type} Affinity: {this.GetAffinity()}";
    }
}