using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Nation
{
	private List<Bender> benders;
	private List<Monument> monuments;

	public Nation()
	{
		this.Benders = new List<Bender>();
		this.Monuments = new List<Monument>();
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

	public double TotalPower()
	{
		return this.Benders.Sum(b => b.Power);
	}

	public double MonumentBonus()
	{
		return this.Monuments.Sum(m => m.Affinity);
	}

	public double GetWarPoints()
	{
		return this.TotalPower() + ((this.TotalPower() / 100) * this.MonumentBonus());
	}

	public override string ToString()
	{
		var sb = new StringBuilder();

		sb.AppendLine($"{this.GetType().Name} Nation");
			

		if (this.Benders.Count > 0)
		{
			sb.AppendLine("Benders:");
			this.Benders.ForEach(b => sb.AppendLine($"###{b.ToString()}"));
		}
		else
		{
			sb.AppendLine("Benders: None");
		}

		if (this.Monuments.Count > 0)
		{
			sb.AppendLine("Monuments:");
			this.Monuments.ForEach(m => sb.AppendLine($"###{this.GetType().Name} Monument: {m.Name}, {this.GetType().Name} Affinity: {m.Affinity}"));
		}
		else
		{
			sb.AppendLine("Monuments: None");
		}
		return sb.ToString().Trim();
	}
}

