using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;
    private string type;

    public Nation(string type)
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
        this.type = type;
    }

    public List<Bender> Benders
    {
        get { return this.benders; }
        set { this.benders = value; }
    }

    public List<Monument> Monuments
    {
        get { return this.monuments; }
        set { this.monuments = value; }
    }

    public double GetNationTotalPoints()
    {
        var totalBenderPoints = this.benders.Sum(b => b.GetTotalPoints());
        var totalAffinityPoints = this.monuments.Sum(m => m.GetAffinity());
        var bonusIncrease = (totalBenderPoints/100)*totalAffinityPoints;
        return totalBenderPoints + bonusIncrease;
    }

    public void LoseWar()
    {
        this.Benders.Clear();
        this.Monuments.Clear();
    }

    public string GetNationType()
    {
        return this.type;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.type} Nation");
        sb.Append("Benders: ");

        if (this.Benders.Count > 0)
        {
            sb.AppendLine();
            this.Benders.ForEach(b => sb.AppendLine(b.ToString()));
        }
        else
        {
            sb.AppendLine("None");
        }

        sb.Append("Monuments: ");

        if (this.Monuments.Count > 0)
        {
            sb.AppendLine();
            this.Monuments.ForEach(m => sb.AppendLine(m.ToString()));
        }
        else
        {
            sb.Append("None");
        }

        return sb.ToString().Trim();
    }
}