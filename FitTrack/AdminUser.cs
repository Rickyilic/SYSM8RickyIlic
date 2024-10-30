using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrack
{
    public class AdminUser : User
    {
        public AdminUser(string username, string password, string country)
            : base(username, password, country) { }

        // Metod för att hantera alla träningspass
        public void ManageAllWorkouts(UserManager userManager)
        {
        }
    }
}
