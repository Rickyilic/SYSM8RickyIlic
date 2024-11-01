using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class StrengthWorkout : Workout
    {
        public int Sets { get; set; }    // Antal set
        public int Repetitions { get; set; } // Antal repetitioner per set

        public StrengthWorkout(string date, int duration, int caloriesBurned, string notes, string username, int sets, int repetitions)
            : base(date, "Strength", duration, caloriesBurned, notes, username)
        {
            Sets = sets;
            Repetitions = repetitions;
            CalculateCaloriesBurned();
        }

        public override int CalculateCaloriesBurned()
        {
            // Enkel formel för kaloriberäkning för styrketräning (exempel)
            CaloriesBurned = (Sets * Repetitions) + (Duration * 8);
            return CaloriesBurned;
        }
    }
}
