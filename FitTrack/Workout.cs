using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public abstract class Workout
    {
        
        
        public string Date { get; set; }
        public string Type { get; set; }
        public int Duration { get; set; }
        public int CaloriesBurned { get; set; }
        public string Notes { get; set; }
        public string Username { get; set; } 


        
        // Visar info om träningspassen i listan med workouts i workoutswindow
        public override string ToString()
        {
            return $"{Date} - {Type}: {Duration} mins, {CaloriesBurned} calories";
        }

        // Konstruktor
        protected Workout(string date, string type, int duration, int caloriesBurned, string notes, string username)
        {
            
            Date = date;
            Type = type;
            Duration = duration;
            CaloriesBurned = caloriesBurned;
            Notes = notes;
            Username = username;
        }

        // Ska ärvas av subklasserna och räkna ut kalorierna
        public abstract int CalculateCaloriesBurned();
    }
}
