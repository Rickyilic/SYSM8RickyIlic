using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitTrack
{
    public class UserManager
    {
        // Lista för att lagra alla användare
        private List<User> users = new List<User>();
        //Lista för att lagra workouts
        private List<Workout> workouts = new List<Workout>();


        // Metod för att registrera en ny användare
        public void RegisterUser(User user)
        {
            if (!UserExists(user.Username))
            {
                users.Add(user);
                MessageBox.Show($"User registered: {user.Username}, {user.Password}");
            }

        }

        // Metod för att logga in användaren med användarnamn och lösenord
        public bool TryLoginUser(string username, string password, out User user)
        {
            user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }

        //Rensar träningspass i min userManager lista
        public void ClearWorkouts()
        {
            workouts.Clear();
        }

        // Kontrollmetod för att se om ett användarnamn redan finns
        public bool UserExists(string username)
        {
            return users.Any(u => u.Username == username);
        }

        // Lägger till träningspass
        public void AddWorkout(Workout workout)
        {
            workouts.Add(workout);
        }

        // Hämtar alla träningspass (för admin)
        public List<Workout> ManageAllWorkouts()
        {
            return workouts; // Returnera alla träningspass
        }

        // Hämtar träningspass för en specifik användare
        public List<Workout> GetUserWorkouts(User user)
        {
            return workouts.Where(w => w.Username == user.Username).ToList();
        }

        // Ta bort träningspass
        public void RemoveWorkout(Workout workout)
        {
            workouts.Remove(workout);
        }

    }

}

