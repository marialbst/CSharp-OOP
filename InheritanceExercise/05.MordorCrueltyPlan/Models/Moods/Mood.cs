namespace _05.MordorCrueltyPlan.Models.Moods
{
    public abstract class Mood
    {
        private string type;

        public Mood(string type)
        {
            this.Type = type;
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
