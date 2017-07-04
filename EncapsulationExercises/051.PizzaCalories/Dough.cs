using System;

namespace _051.PizzaCalories
{
    public class Dough
    {
        private const double Base = 2.0;
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0; 

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            set
            {
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double GetDoughCalories()
        {
            double flourMod = GetFlourMod();
            double bTechMod = GetBTechMod();

            return this.weight * Base * flourMod * bTechMod;
        }

        private double GetBTechMod()
        {
            switch (this.bakingTechnique.ToLower())
            {
                case "crispy": return Crispy;
                case "chewy": return Chewy;
                default:return Homemade;
            }
        }

        private double GetFlourMod()
        {
            return this.flourType.ToLower() == "white" ? White : Wholegrain;
        }
    }
}
