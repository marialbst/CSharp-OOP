namespace _05.MordorCrueltyPlan.Models.Foods
{
    public abstract class Food
    {
        private int happiness;

        public Food(int happiness)
        {
            this.Happiness = happiness;
        }

        public int Happiness
        {
            get { return this.happiness; }
            set { this.happiness = value; }
        }
    }
}
