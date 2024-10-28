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
        public bool TryLoginUser(string username, string password, out User user)
        {
            user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }

        // Kontrollmetod för att se om ett användarnamn redan finns
        public bool UserExists(string username)
        {
            return users.Any(u => u.Username == username);
        }
    }

}

