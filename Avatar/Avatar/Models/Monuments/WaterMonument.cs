﻿public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity
    {
        get { return waterAffinity; }
        set { waterAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.WaterAffinity;
    }
}