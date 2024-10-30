using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class User : Person
    {

        public string Country { get; set; }

        public User(string username, string password, string country)
            : base(username, password)
        {

            Country = country;

        }

        // Implementerar SignIn-metoden
        public override bool SignIn(string password)
        {
            return Password == password;
        }
    }
}
