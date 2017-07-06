namespace _05.MordorCrueltyPlan.Models
{
    using Foods;
    using Moods;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class GandalfTheGray
    {
        private List<Food> foods;
        private Mood mood;
        MoodFactory mf = new MoodFactory();
        private int points;

        public GandalfTheGray(List<Food> foods)
        {
            this.Foods = foods;
            this.points = this.GetPoints(this.Foods);
            this.mood = mf.GetMood(this.points);  
        }

        private List<Food> Foods
        {
            get { return this.foods; }
            set { this.foods = value; }
        }

        private int GetPoints(List<Food> foods)
        {
            return foods.Sum(t => t.Happiness);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.points}")
                .Append($"{this.mood.Type}");

            return sb.ToString();
        }
    }
}
