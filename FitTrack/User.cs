using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public bool IsAdmin { get; set; } = false;

        // Konstruktor för att skapa en ny användare med nödvändiga uppgifter

        public User(string username, string password, string country, bool isAdmin = false)
        {
            Username = username;
            Password = password;
            Country = country;
            IsAdmin = isAdmin; // Som standard är IsAdmin false för vanliga användare
        }
    }
}
