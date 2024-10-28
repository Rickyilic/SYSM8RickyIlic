using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class UserManager
    {
        // Lista för att lagra alla användare
        private List<User> users = new List<User>();


        // Metod för att registrera en ny användare
        public void RegisterUser(User user)
        {
            users.Add(user);
        }

        // Metod för att logga in användaren med användarnamn och lösenord
        public User LoginUser(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        // Kontrollmetod för att se om ett användarnamn redan finns
        public bool UserExists(string username)
        {
            return users.Any(u => u.Username == username);
        }
    }

}

