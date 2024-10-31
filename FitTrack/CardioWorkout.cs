using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitTrack
{
    public class CardioWorkout : Workout
    {

        public int Distance { get; set; } // Avstånd i kilometer

        public CardioWorkout(string date, int duration, int caloriesBurned, string notes, string username, int distance)
            : base(date, "Cardio", duration, caloriesBurned, notes, username)
        {
            Distance = distance;
        }

        public override int CalculateCaloriesBurned()
        {
            // Enkel formel för kaloriberäkning för konditionsträning testexempel
            CaloriesBurned = (Duration * 10) + (Distance * 5);
            return CaloriesBurned;
        }
    }
}
