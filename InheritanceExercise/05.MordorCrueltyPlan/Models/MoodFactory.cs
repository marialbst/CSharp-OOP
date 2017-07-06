﻿namespace _05.MordorCrueltyPlan.Models
{
    using Moods;

    public class MoodFactory
    {
        public Mood GetMood(int points)
        {
            if(points < -5)
            {
                return new Angry();
            }
            else if(points >= -5 && points <= 0)
            {
                return new Sad();
            }
            else if(points <= 15)
            {
                return new Happy();
            }
            return new JavaScript();
        }
    }
}
